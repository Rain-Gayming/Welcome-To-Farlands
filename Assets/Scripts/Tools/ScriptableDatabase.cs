using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Databases/ItemDataBase")]
public class ScriptableDatabase : ScriptableObject
{
    public List<ItemBase> itemsInDatabase;
    [ContextMenu("SetIds")]
    public void SetIDs()
    {
        for (int i = 0; i < itemsInDatabase.Count; i++)
        {
            itemsInDatabase[i].itemID = i;
        }
    }
}
