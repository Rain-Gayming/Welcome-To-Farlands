using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Container : Item
{
    public List<EItemType> itemsAllowedInContainer;
    public int maxItems;
}
