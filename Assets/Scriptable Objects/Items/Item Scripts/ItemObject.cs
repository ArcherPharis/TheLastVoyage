using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Seedling, //consumable objects used for crafting or serve as ammunition.
    Tool, // Equipped on the player, either a tool, or Efiyae. Some may or may not alter stats.
    Efiyae,
    GasMask,
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
    LightningAffinity,
    WindAffinity
}

public abstract class ItemObject : ScriptableObject
{
    public Sprite uiDisplay;
    public GameObject characterDisplay;
    public bool stackable;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public Item data = new Item();

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
    public int ID = -1;
    public ItemBuff[] buffs;
    public Item()
    {
        Name = "";
        ID = -1;
    }


    public Item(ItemObject item)
    {
        Name = item.name;
        ID = item.data.ID;
        buffs = new ItemBuff[item.data.buffs.Length];
        for(int i =0; i < buffs.Length; i++)
        {
            
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max);
            buffs[i].attribute = item.data.buffs[i].attribute;
        }
    }
}

[System.Serializable]
public class ItemBuff : IModifiers
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

    public void AddValue(ref int baseValue)
    {
        baseValue += value;
    }

    public void GenerateValues()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}
