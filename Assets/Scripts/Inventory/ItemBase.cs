using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : ScriptableObject
{
    public int itemID;
    public string itemName;
    public Sprite icon;
    public bool stacks;
    public EItemType itemType; 
}

[System.Serializable]
public class Item
{
    public ItemBase baseItem;
    public int amount;
}