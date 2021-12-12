using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{



    public InventoryObject inventory;
    public InventoryObject equipment;
    public Attribute[] attributes;
    [SerializeField] GameObject spellList;

    private Transform tools;
    private Transform powers;

    public Transform toolTransform;
    public Transform powerTransform;
    ItemObject obh;
    bool spellIsThere = false;
    public float currentOxygen;
    [SerializeField] float oxygenDegredationRate = 2f;
    [SerializeField]Text oxygenText;



    

    

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, " was increased. Value of stat is now ", attribute.value.ModifiedValue));
    }


    public void AddOxygenAtStart()
    {
        int oxy = attributes[3].value.ModifiedValue;
        currentOxygen = oxy + 10;

    }

    public void Test(Attribute attribute)
    {
        float newValueOfOxygen = attributes[3].value.ModifiedValue;
        currentOxygen = newValueOfOxygen;
    }




    public void FireCheck(Attribute attribute)
    {
        

        int valueOfStat = attributes[5].value.ModifiedValue;
        valueOfStat = attribute.value.ModifiedValue;



        if (valueOfStat == 3)
        {
            //var item = spellList.GetComponent<SpellList>();

            spellIsThere = true;
            //if (item)
            //{
            //    //Item _item = new Item(item.spells);
            //    //inventory.AddItem(_item, 1);
            //    


            //}

        }
        else if( valueOfStat <= 3)
        {
            spellIsThere = false;
        }
    }

    public bool SpellCheck()
    {
        return spellIsThere;
    }



    private void OnApplicationQuit()
    {
        inventory.Clear();
        equipment.Clear();

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        AddOxygenAtStart();

    


        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnRemoveItem;
            equipment.GetSlots[i].OnAfterUpdate += OnAddItem;
        }

        
    }

    void Death()
    {
        if(currentOxygen <= 0)
        {
            SceneManager.LoadScene("TestScene");
        }
    }

    private void Update()
    {

        //AddOxygenAtStart();
        Death();

        currentOxygen -= Time.deltaTime * oxygenDegredationRate;


        oxygenText.text = currentOxygen.ToString();
        //FireCheck(attributes[5]);
    }


    public void OnRemoveItem(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Removed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, " Allowed Items: " , string.Join(", ", _slot.AllowedItems)));

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.RemoveModifier(_slot.item.buffs[i]);
                    }
                }

                if (_slot.ItemObject.characterDisplay != null)
                {
                    switch (_slot.AllowedItems[0])
                    {

                        case ItemType.Powers:
                            Destroy(powers.gameObject);
                            break;
                        case ItemType.Tool:
                            Destroy(tools.gameObject);
                            break;



                    }
                }

                break;
            case InterfaceType.Craft:
                break;
            default:
                break;
        }

    }

    public void OnAddItem(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:



                break;
            case InterfaceType.Equipment:
                print(string.Concat("Placed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, " Allowed Items: ", string.Join(", ", _slot.AllowedItems)));

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.AddModifier(_slot.item.buffs[i]);
                    }
                }
                if(_slot.ItemObject.characterDisplay != null)
                {
                    switch (_slot.AllowedItems[0])
                    {

                        case ItemType.Powers:
                            powers = Instantiate(_slot.ItemObject.characterDisplay, powerTransform).transform;
                            break;
                        case ItemType.Tool:
                            tools = Instantiate(_slot.ItemObject.characterDisplay, toolTransform).transform;
                            break;


                            
                    }
                }



                break;
            case InterfaceType.Craft:
                break;
            default:
                break;
        }
    }

}

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public Player parent;
    public Attributes type;
    public ModifiableInt value;

    public void SetParent(Player _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
        
    }

    
    public void AttributeModified()
    {
        parent.FireCheck(this);
        parent.AttributeModified(this);
        parent.Test(this);
        

    }

    

}
