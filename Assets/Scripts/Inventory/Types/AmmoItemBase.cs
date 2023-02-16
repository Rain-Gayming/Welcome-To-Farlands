using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Ammo")]
public class AmmoItemBase : ItemBase
{
    [Header("Ammo Info")]
    public int physicalDamage;
    public int explosiveDamage;
    public int fireDamage;

    public int pellets;

    public EAmmoCaliber ammoCaliber;
}