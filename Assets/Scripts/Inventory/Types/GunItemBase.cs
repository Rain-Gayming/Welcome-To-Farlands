using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Gun")]
public class GunItemBase : ItemBase
{
    [Header("Gun Info")]
    public GunStats stats;
    public EGunType gunType;
    public EAmmoCaliber[] ammoCaliber;
    public GameObject gunPrefab;
}

