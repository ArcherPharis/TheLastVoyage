using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    private static Inputs _InputInstance;

    public static Inputs InputInstance
    {
        get { return _InputInstance; }
    }

    PlayerInputs playerInputs;

    private void Awake()
    {
        if(_InputInstance != null && _InputInstance != this) //prevents two instances of input script
        {
            Destroy(this.gameObject);
        }
        else
        {
            _InputInstance = this;
        }
        playerInputs = new PlayerInputs();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    void OnDisable()
    {
        playerInputs.Disable();
    }

    public Vector2 GetPlayerLoc()
    {
        return playerInputs.PlayerMovement.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseLoc()
    {
        return playerInputs.PlayerMovement.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumped()
    {
        return playerInputs.PlayerMovement.Jump.triggered;
    }
}
