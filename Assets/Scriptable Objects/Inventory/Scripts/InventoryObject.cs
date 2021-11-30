using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory ContainerOfInventory;




    public void AddItem(Item _item, int _quantity)
    {
        if (_item.buffs.Length > 0) //if an item has buffs, don't stack it.
        {
            SetEmptySlot(_item, _quantity);
            return;
        }

        for (int i = 0; i < ContainerOfInventory.Items.Length; i++) //if there's less than 0 items, add an item.
        {
            if (ContainerOfInventory.Items[i].ID == _item.ID) //if the item equals the item, add another item, then stop.
            {
                ContainerOfInventory.Items[i].AddQuantity(_quantity);
                return;
            }
        }
        SetEmptySlot(_item, _quantity);



    }
    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < ContainerOfInventory.Items.Length; i++)
        {
            if(ContainerOfInventory.Items[i].ID <= -1)
            {
                ContainerOfInventory.Items[i].UpdateSlot(_item.ID, _item, _amount);
                return ContainerOfInventory.Items[i];
            }
        }
        //TODO replace this with logic when inventory is full.
        return null;
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
            ContainerOfInventory = (Inventory)formatter.Deserialize(stream);
            stream.Close();

        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        ContainerOfInventory = new Inventory();
    }


}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] Items = new InventorySlot[7];
}

[System.Serializable]
public class InventorySlot
{
    public int ID = -1;
    public Item item;
    public int quantityOfItems;

    public InventorySlot()
    {
        ID = -1;
        item = null;
        quantityOfItems = 0;
    }
    public InventorySlot(int _ID, Item _item, int _quantity)//constructor
    {
        ID = _ID;
        item = _item;
        quantityOfItems = _quantity;
    }

    public void UpdateSlot(int _ID, Item _item, int _quantity)
    {
        ID = _ID;
        item = _item;
        quantityOfItems = _quantity;
    }

    public void AddQuantity(int value)
    {
        quantityOfItems += value;
    }
}
