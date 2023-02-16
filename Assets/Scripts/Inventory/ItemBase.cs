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

    [Header("Item References")]
    public ExplosiveItemBase explosiveItemReference;
    public AmmoItemBase ammoItemReference;
    public GunItemBase gunItemReference;
    public MeleeItemBase meleeItemReference;
    public ArmourItemBase armourItemReference;
    public JunkItemBase junkItemReference;
    public MedicalItemBase medicalItemReference;
    public MiscItemBase miscItemReference;
    public NotesItemBase notesItemReference;
}

[System.Serializable]
public class Item
{
    public ItemBase baseItem;
    public int amount;

    public Item(ItemBase _base, int _amount){
        baseItem = _base;
        amount = _amount;
    }
}