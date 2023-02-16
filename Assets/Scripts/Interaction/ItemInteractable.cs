using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    public Item itemToAdd;

    public override void Interact()
    {
        Inventory.instance.AddItem(itemToAdd);
        Destroy(gameObject);    
    }
}
