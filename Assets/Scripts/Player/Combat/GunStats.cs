using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunStats : ScriptableObject
{
    [Header("Firemodes")]
    public bool canBeAutomatic;

    [Header("Animation")]
    public int animationLayer;
    public float reloadTime;

    [Header("Stats")]
    public int maxAmmo;
    public float range;
    public float fireRate;
    public float damage;
}
