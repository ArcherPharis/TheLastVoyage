using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Element, //consumable objects used for crafting or serve as ammunition.
    Equipment, // Equipped on the player, either a tool, or Efiyae. Some may or may not alter stats.
    Powers, // abilities that can be used at any time and consume the energy meter or phrases that consume inventory items.
    Consumables, //found or crafted restorative or altering, crafted damaging items.
    Default //key items, stuff like keys and stuff that only stays in the inventory.
}

public enum Attributes
{
    Health,
    Agility,
    Power,
    Oxygen,
    Energy,
    FireAffinity,
    WaterAffinity,
    IceAffinity,
    LightningAffinity
}

public abstract class ItemObject : ScriptableObject
{
    public int ID;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public ItemBuff[] buffs;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]

public class Item
{
    public string Name;
    public int ID;
    public ItemBuff[] buffs;
    public Item(ItemObject item)
    {
        Name = item.name;
        ID = item.ID;
        buffs = new ItemBuff[item.buffs.Length];
        for(int i =0; i < buffs.Length; i++)
        {
            
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max);
            buffs[i].attribute = item.buffs[i].attribute;
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;

    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValues();
    }

    public void GenerateValues()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}
