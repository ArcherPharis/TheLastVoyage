using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    public InventoryObject inventory;





    private void OnApplicationQuit()
    {
        inventory.ContainerOfInventory.Items = new InventorySlot[7];
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


}
