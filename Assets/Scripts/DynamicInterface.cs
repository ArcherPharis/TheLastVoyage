using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicInterface : UserInterface
{
    public GameObject inventoryPrefab;
    public int startingYPos;
    public int startingXPos;
    public int XspaceBetweenItems;
    public int YspaceBetweenItems;
    public int itemsPerColumn;

    public override void CreateSlots()
    {
        slotsDisplayedOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            inventory.GetSlots[i].slotDisplay = obj;

            slotsDisplayedOnInterface.Add(obj, inventory.ContainerOfInventory.Slots[i]);
        }
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(startingXPos + (XspaceBetweenItems * (i % itemsPerColumn)), startingYPos + (-YspaceBetweenItems * (i / itemsPerColumn)), 0f);
    }
}
