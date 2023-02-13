using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AmmoItemBase : ItemBase
{
    
}

[System.Serializable]
public class AmmoItem
{
    public AmmoItemBase ammoBase;
    public int amount;
}