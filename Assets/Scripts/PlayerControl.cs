
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    Transform cameraTransform;
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] private float runSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] Camera cam;
    [SerializeField] float interactDistance;
    [SerializeField] bool notRunning = true;
    Inputs inputs;
    Player player;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputs = Inputs.InputInstance;
        cameraTransform = Camera.main.transform;
        player = GetComponent<Player>();        
    }



    void Save()
    {
        if (inputs.PlayerSaved())
        {
            player.inventory.Save();
            Debug.Log("Player saved!");
        }
        
    }

    void Load()
    {
        if (inputs.PlayerLoaded())
        {
            player.inventory.Load();
            Debug.Log("Player loaded!");
        }
        
    }

    void Interact()
    {
        RaycastHit interacted;
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(Physics.Raycast(ray, out interacted, interactDistance) && inputs.PlayerInteracted())
        {
            var item = interacted.collider.GetComponent<GroundItem>();

            if (item)
            {
                player.inventory.AddItem(new Item(item.item), 1);
                Destroy(interacted.collider.gameObject);
            }
        }




    }
    
    public void PlayerRun()
    {
        float originalSpeed = playerSpeed;
        float newSpeed = 8f;
        
        if (notRunning)
        {
            playerSpeed = 4f;
        }
        else if(inputs.PlayerIsSprinting())
        {

            playerSpeed = newSpeed;
        }

        if (inputs.PlayerIsPressingSprint())
        {
            
            notRunning = false;
            
            
            
        }
        else
        {
            notRunning = true;
        }

     
        Debug.Log(originalSpeed);


    }

    void Update()
    {

        Interact();
        Save();
        Load();
        PlayerRun();

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 movement = inputs.GetPlayerLoc();
        Vector3 move = new Vector3(movement.x, 0, movement.y); //this turns our vector2 into one compatible for 3D Movement. 0 because we don't want to move up, but forward.
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);



        // Changes the height position of the player..
        if (inputs.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
    }
}
