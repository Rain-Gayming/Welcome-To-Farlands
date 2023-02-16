using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunStats : ScriptableObject
{
    [Header("Firemodes")]
    public bool canBeAutomatic;
    public bool shotgun;

    [Header("Animation")]
    public int animationLayer;
    public float reloadTime;

    [Header("Stats")]
    public int maxAmmo;
    public float range;
    public float fireRate;
    public float damage;

    [Header("Recoil")]
    public float pointFireRecoilX;
    public float pointFireRecoilY;
    public float pointFireRecoilZ;
    public float aimRecoilX;
    public float aimRecoilY;
    public float aimRecoilZ;
    public float snappiness;
    public float returnSpeed;

    [Header("Shotgun Info")]
    public float rangeX;
    public float rangeY;
}
