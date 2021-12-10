using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;


public enum InterfaceType
{
    Inventory,
    Equipment,
    Craft
}

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public InterfaceType type;
    public Inventory ContainerOfInventory;
    public InventorySlot[] GetSlots { get { return ContainerOfInventory.Slots; } }
    InventorySlot itemobj;




    public bool AddItem(Item _item, int _quantity)
    {
        
        if(EmptySlotCount <= 0)
        
            return false;

        InventorySlot slot = FindItemInInventory(_item);
        if(!database.ItemsObjects[_item.ID].stackable || slot == null)
        {
            SetEmptySlot(_item, _quantity);
            return true;
        }
        slot.AddQuantity(_quantity);
        return true;
        


    }

    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < GetSlots.Length; i++)
            {
                if(GetSlots[i].item.ID <= -1)
                
                    counter++;
              
            }
            return counter;
        }
    }

    public InventorySlot FindItemInInventory(Item _item)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if(GetSlots[i].item.ID == _item.ID)
            {
                return GetSlots[i];
            }
        }
        return null;
    }
    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if(GetSlots[i].item.ID <= -1)
            {
                GetSlots[i].UpdateSlot(_item, _amount);
                return GetSlots[i];
            }
        }
        //TODO replace this with logic when inventory is full.
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2) //once called swapitem
    {

        if (item2.CanPlaceInSlot(item1.ItemObject) && item1.CanPlaceInSlot(item2.ItemObject))
        {
            InventorySlot temp = new InventorySlot(item2.item, item2.quantityOfItems);
            item2.UpdateSlot(item1.item, item1.quantityOfItems);
            item1.UpdateSlot(temp.item, temp.quantityOfItems);
        }
      
    }

    public void DropItem(Item item)
    {
        for (int i = 0; i < ContainerOfInventory.Slots.Length; i++)
        {
            if(ContainerOfInventory.Slots[i].item == item)
            {
                ContainerOfInventory.Slots[i].UpdateSlot(null, 0);
            }
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, ContainerOfInventory);
        stream.Close();

    }

    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory NewContainerOfInventory = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < GetSlots.Length; i++)
            {
                GetSlots[i].UpdateSlot(NewContainerOfInventory.Slots[i].item, NewContainerOfInventory.Slots[i].quantityOfItems);
            }
            stream.Close();

        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        ContainerOfInventory.Clear();
    }
    
    public void ClearPower()
    {
        itemobj.RemoveItem();
    }


}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] Slots = new InventorySlot[7];
    public void Clear()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].RemoveItem();
        }
    }
}

public delegate void SlotUpdated(InventorySlot _slot);

[System.Serializable]
public class InventorySlot
{
    public ItemType[] AllowedItems = new ItemType[0]; //what items can go in which slots
    [System.NonSerialized]
    public UserInterface parent;
    [System.NonSerialized]
    public GameObject slotDisplay;
    [System.NonSerialized]
    public SlotUpdated OnAfterUpdate;
    [System.NonSerialized]
    public SlotUpdated OnBeforeUpdate;
    public Item item = new Item();
    public int quantityOfItems;

    public ItemObject ItemObject
    {
        get
        {
            if(item.ID >= 0)
            {
                return parent.inventory.database.ItemsObjects[item.ID];
            }
            return null;
        }
    }

    public InventorySlot()
    {
        UpdateSlot(new Item(), 0);

    }
    public InventorySlot(Item _item, int _quantity)//constructor
    {

        UpdateSlot(_item, _quantity);
    }

    public void UpdateSlot(Item _item, int _quantity)
    {
        if (OnBeforeUpdate != null)
            OnBeforeUpdate.Invoke(this);

        item = _item;
        quantityOfItems = _quantity;
        if (OnAfterUpdate != null)
            OnAfterUpdate.Invoke(this);
    }

    public void RemoveItem()
    {
        UpdateSlot(new Item(), 0);
    }

    public void AddQuantity(int value)
    {
        UpdateSlot(item, quantityOfItems += value);

    }

    public bool CanPlaceInSlot(ItemObject _itemObject)
    {
        if (AllowedItems.Length <= 0 || _itemObject == null || _itemObject.data.ID < 0)
            return true;

        for (int i = 0; i < AllowedItems.Length; i++)
        {
            if(_itemObject.type == AllowedItems[i])
            
                return true;
            
            
        }
        return false;
    }
}
