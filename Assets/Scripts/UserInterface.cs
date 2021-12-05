using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public abstract class UserInterface : MonoBehaviour
{


    public Player player;
    public InventoryObject inventory;

    public Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventory.ContainerOfInventory.Items.Length; i++)
        {
            inventory.ContainerOfInventory.Items[i].parent = this;
        }

        CreateSlots();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
            if (_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.ID].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.quantityOfItems == 1 ? "" : _slot.Value.quantityOfItems.ToString("n0"); //if it's 1, and if it's not.
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    public abstract void CreateSlots();



    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        player.mousedItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
            player.mousedItem.hoverItem = itemsDisplayed[obj];

    }

    public void OnDrag(GameObject obj)
    {
        if (player.mousedItem.obj != null)
        {
            player.mousedItem.obj.GetComponent<RectTransform>().position = Mouse.current.position.ReadValue();
        }
    }

    public void OnDragEnd(GameObject obj)
    {
        var itemOnMouse = player.mousedItem;
        var mouseHoverItem = itemOnMouse.hoverItem;
        var mouseHoverObj = itemOnMouse.hoverObj;
        var GetItemObject = inventory.database.GetItem;


        if (itemOnMouse.ui != null)
        {
            if (mouseHoverObj)
            
                if (mouseHoverItem.CanPlaceInSlot(GetItemObject[itemsDisplayed[obj].ID]) && (mouseHoverItem.item.ID <= -1 || (mouseHoverItem.item.ID >= 0 && itemsDisplayed[obj].CanPlaceInSlot(GetItemObject[mouseHoverItem.item.ID]))))
                    inventory.MoveItem(itemsDisplayed[obj], mouseHoverItem.parent.itemsDisplayed[itemOnMouse.hoverObj]);
            
        }
        else
        {
            inventory.DropItem(itemsDisplayed[obj].item);

            //TODO for now, this only removes the item. In the future let's make it drop as to create cool
            //reactions in the world by dropping an ice item in a pool of lava or something.
        }
        Destroy(itemOnMouse.obj);
        itemOnMouse.item = null;
    }

    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rectTransform = mouseObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(50, 50);
        mouseObject.transform.SetParent(transform.parent);

        if (itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
            img.raycastTarget = false;
        }
        player.mousedItem.obj = mouseObject;
        player.mousedItem.item = itemsDisplayed[obj];
    }

    public void OnExit(GameObject obj)
    {
        player.mousedItem.hoverObj = null;
        player.mousedItem.hoverItem = null;
    }

    public void OnExitInterface(GameObject obj)
    {
        player.mousedItem.ui = null;
    }

    public void OnEnterInterface(GameObject obj)
    {
        player.mousedItem.ui = obj.GetComponent<UserInterface>();
    }




}

public class MouseItem
{

    public UserInterface ui;
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;
}
