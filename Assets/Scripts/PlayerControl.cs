
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    Inputs inputs;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputs = Inputs.InputInstance;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 movement = inputs.GetPlayerLoc();
        Vector3 move = new Vector3(movement.x, 0, movement.y); //this turns our vector2 into one compatible for 3D Movement. 0 because we don't want to move up, but forward.
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (inputs.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
