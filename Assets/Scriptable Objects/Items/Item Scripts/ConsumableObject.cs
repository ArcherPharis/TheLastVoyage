using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Consumable Object", menuName = "Inventory System/Items/Consumables")]
public class ConsumableObject : ItemObject
{


    public void Awake()
    {
        type = ItemType.Consumables;
    }
}
