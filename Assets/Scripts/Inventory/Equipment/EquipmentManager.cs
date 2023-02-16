using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    public GameObject weaponPoint;
    public GameObject gunItemObj;
    public float rot;

    [Header("Armour")]
    public Item headItem;
    public Item chestItem;
    public Item legsItem;
    public Item bootsItem;
    public Item underArmourItem;
    public Item clothingItem;

    [Header("Weapons")]
    public Item meleeWeapon;
    public Item ammoItem;
    public Item gunItem;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gunItemObj.transform.rotation = new Quaternion(0, rot, 0, 0);
    }

    public void UpdateWeapon()
    {
        Quaternion savedRot = GetComponentInChildren<Camera>().transform.rotation;
        GetComponentInChildren<Camera>().transform.rotation = Quaternion.identity;
        Destroy(gunItemObj);
        GameObject newGunPoint = Instantiate(gunItem.baseItem.gunItemReference.gunPrefab);
        newGunPoint.transform.parent = weaponPoint.transform;
        gunItemObj = newGunPoint;
        GetComponentInChildren<Camera>().transform.rotation = savedRot;
    }
}
