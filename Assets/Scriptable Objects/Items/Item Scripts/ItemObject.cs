using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Element, //consumable objects used for attacking, crafting, and a bunch of things. Also included crafted offensive items.
    Equipment, // tools equipped in the player's hand, stuff like lanterns, levers, and drills.
    Powers, // abilities that can be used at any time and consume the energy meter. 
    Consumables, //found or crafted restorative or altering
    Default //key items, stuff like keys and stuff that only stays in the inventory.
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}
