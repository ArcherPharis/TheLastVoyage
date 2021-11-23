using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> ContainerOfInventory = new List<InventorySlot>();

    public void AddItem(ItemObject _item, int _quantity)
    {
        bool hasItem = false;

        for(int i = 0; i < ContainerOfInventory.Count; i++) //if there's less than 0 items, add an item.
        {
            if(ContainerOfInventory[i].item == _item)
            {
                ContainerOfInventory[i].AddQuantity(_quantity);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            ContainerOfInventory.Add(new InventorySlot(_item, _quantity)); //adds the stuff if it's not there.
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int quantityOfItems;
    public InventorySlot(ItemObject _item, int _quantity)//constructor
    {
        item = _item;
        quantityOfItems = _quantity;
    }

    public void AddQuantity(int value)
    {
        quantityOfItems += value;
    }
}
