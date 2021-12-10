using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Telekinesis : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float maxGrabDistance = 10f;
    [SerializeField] float throwforce = 20f;
    [SerializeField] float lerpSpeed = 10f;
    [SerializeField] Transform objectHolder;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectileMuzzle;
    [SerializeField] Transform firePoint;
    [SerializeField] float projectileSpeed = 30f;
    [SerializeField] float fireRate = 2f;
    [SerializeField] float arcRange = 1f;
    [SerializeField] Player player;
    [SerializeField] InGameUI inGameUI;
    float timeToFire;


    PlayerInputs inputActions;

    Rigidbody grabbedRB;
    Vector3 destination;

    private void Awake()
    {
        inputActions = new PlayerInputs();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Start()
    {
        inputActions.PlayerMovement.Lift.performed += Lift;
        inputActions.PlayerMovement.Throw.performed += Throw;
        inputActions.PlayerMovement.Power1.performed += UseAbilityOne;
        inputActions.UI.Pause.performed += TogglePause;

        if (inGameUI == null)
        {
            inGameUI = FindObjectOfType<InGameUI>();
        }
    }

    private void TogglePause(InputAction.CallbackContext obj)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            if (inGameUI != null)
            {
                inGameUI.SwitchInGamePanel();
                inputActions.PlayerMovement.Enable();
            }
        }
        else
        {
            Time.timeScale = 0;
            if (inGameUI)
            {
                inGameUI.SwitchPausePanel();
                inputActions.PlayerMovement.Disable();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsItGrabbed();
    }

    bool IsItGrabbed()
    {
        if (grabbedRB)
        {
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position,objectHolder.transform.position, Time.deltaTime * lerpSpeed));
            return true;
        }
        return false;
    }


    void Lift(InputAction.CallbackContext obj)
    {
        

        if (grabbedRB)
        {
            grabbedRB.isKinematic = false;
            grabbedRB = null;
        }
        else
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit, maxGrabDistance))
            {
                Debug.Log("am i picking it up?");
                grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                if (grabbedRB)
                {
                    grabbedRB.isKinematic = true;
                }
            }
        }
    }

    void Throw(InputAction.CallbackContext obj)
    {
        if (IsItGrabbed())
        {
            grabbedRB.isKinematic = false;
            grabbedRB.AddForce(cam.transform.forward * throwforce, ForceMode.VelocityChange);
            grabbedRB = null;
        }


    }

    void UseAbilityOne(InputAction.CallbackContext obj)
    {
        if (Time.time >= timeToFire && player.SpellCheck())
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out hit))

            destination = hit.point;

        else

        destination = ray.GetPoint(1000);
        InstantiateProjectile(firePoint);

    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, firePoint.rotation);
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2f));

        var muzzleObj = Instantiate(projectileMuzzle, firePoint.position, firePoint.rotation);
        Destroy(muzzleObj, 2);
    }
}
