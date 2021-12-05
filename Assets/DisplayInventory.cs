using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class DisplayInventory : MonoBehaviour
{
    public MouseItem mousedItem = new MouseItem();

    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    public int startingYPos;
    public int startingXPos;

    public int XspaceBetweenItems;
    public int YspaceBetweenItems;
    public int itemsPerColumn;
    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();


    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }

    public void UpdateSlots()
    {
        foreach(KeyValuePair<GameObject, InventorySlot>_slot in itemsDisplayed)
        {
            if(_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.ID].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.quantityOfItems == 1 ? "" : _slot.Value.quantityOfItems.ToString("n0"); //if it's 1, and if it's not.
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text  = "";
            }
        }
    }

    public void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.ContainerOfInventory.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });


            itemsDisplayed.Add(obj, inventory.ContainerOfInventory.Items[i]);
        }
    }



    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        mousedItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
            mousedItem.hoverItem = itemsDisplayed[obj];

    }

    private void OnDrag(GameObject obj)
    {
        if (mousedItem.obj != null)
        {
            mousedItem.obj.GetComponent<RectTransform>().position = Mouse.current.position.ReadValue();
        }
    }

    private void OnDragEnd(GameObject obj)
    {
        if (mousedItem.hoverObj)
        {
            inventory.MoveItem(itemsDisplayed[obj], itemsDisplayed[mousedItem.hoverObj]);
        }
        else
        {
            inventory.DropItem(itemsDisplayed[obj].item);

            //TODO for now, this only removes the item. In the future let's make it drop as to create cool
            //reactions in the world by dropping an ice item in a pool of lava or something.
        }
        Destroy(mousedItem.obj);
        mousedItem.item = null;
    }

    private void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rectTransform = mouseObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(50, 50);
        mouseObject.transform.SetParent(transform.parent);

        if(itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
            img.raycastTarget = false;
        }
        mousedItem.obj = mouseObject;
        mousedItem.item = itemsDisplayed[obj];
    }

    private void OnExit(GameObject obj)
    {
        mousedItem.hoverObj = null;
        mousedItem.hoverItem = null;
    }



    public Vector3 GetPosition(int i)
    {
        return new Vector3(startingXPos + (XspaceBetweenItems * (i % itemsPerColumn)), startingYPos + (-YspaceBetweenItems * (i / itemsPerColumn)), 0f);
    }
}


