using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver //this allows us to serialize the Dictionary.
{

    public ItemObject[] ItemsObjects; //list of ALL items within the game.
    //public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();
    public void OnAfterDeserialize()
    {

        for(int i = 0; i< ItemsObjects.Length; i++)
        {
            ItemsObjects[i].data.ID = i;
            //GetItem.Add(i, Items[i]);
        }

    }

    public void OnBeforeSerialize()
    {
        //GetItem = new Dictionary<int, ItemObject>();
    }
}
