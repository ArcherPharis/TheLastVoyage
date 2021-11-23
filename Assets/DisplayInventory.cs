using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int startingYPos;
    public int startingXPos;

    public int XspaceBetweenItems;
    public int YspaceBetweenItems;
    public int itemColumns;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.ContainerOfInventory.Count; i++)
        {
            var obj = Instantiate(inventory.ContainerOfInventory[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.ContainerOfInventory[i].quantityOfItems.ToString("n0");
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(startingXPos +( XspaceBetweenItems * (i % itemColumns)), startingYPos + (-YspaceBetweenItems * (i/itemColumns)), 0f);
    }
}
