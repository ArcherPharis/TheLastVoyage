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

    PlayerInputs inputActions;

    Rigidbody grabbedRB;

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
}
