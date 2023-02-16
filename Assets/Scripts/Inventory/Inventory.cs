using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject inventoryUI;
    public List<ItemSlotDisplay> itemSlotDisplays;
    public GameObject itemDisplayPrefab;

    [Header("Weapon Catagories")]
    public GameObject meleeCatagory;
    public GameObject explosivesCatagory;
    public GameObject rifleCatagory;
    public GameObject pistolCatagory;
    public GameObject sniperCatagory;
    public GameObject shotgunCatagory;
    public GameObject smgsCatagory;

    [Header("Armour Catagories")]
    public GameObject headCatagory;
    public GameObject chestCatagory;
    public GameObject legsCatagory;
    public GameObject bootsCatagory;
    public GameObject handCatagory;
    public GameObject underArmourCatagory;
    public GameObject clothingCatagory;
    
    [Header("Item Catagories")]
    public GameObject medicalCatagory;
    public GameObject junkCatagory;
    public GameObject notesCatagory;
    public GameObject miscCatagory;
    public GameObject ammoCatagory;

    [Header("Debug")]

    public Item itemToDebug;
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
        if(InputManager.instance.inventory){
            MenuManager.instance.CloseAllMenus();
            if(GetComponent<Menu>().open){
                InputManager.instance.inventory = false;
                InGameManager.instance.paused = false;
                GetComponent<Menu>().open = false;
            }else{
                InputManager.instance.inventory = false;
                InGameManager.instance.paused = true;
                GetComponent<Menu>().open = true;
            }
        }
    }

    public void AddItem(Item itemToAdd)
    {
        Debug.Log("Adding Item");
        if(itemSlotDisplays.Count > 0 && itemToAdd.baseItem.stacks)
        {
            for (int i = 0; i < itemSlotDisplays.Count; i++)
            {
                if(itemSlotDisplays[i].itemInSlot.baseItem == itemToAdd.baseItem)
                {
                    itemSlotDisplays[i].itemInSlot.amount += itemToAdd.amount;
                }
            }
        }else if(itemSlotDisplays.Count == 0 && itemToAdd.baseItem.stacks){
            GameObject itemSlot = Instantiate(itemDisplayPrefab);
            itemSlot.GetComponent<ItemSlotDisplay>().itemInSlot = itemToAdd;
            itemSlotDisplays.Add(itemSlot.GetComponent<ItemSlotDisplay>());
#region  adding types
            if(itemToAdd.baseItem.gunItemReference)
            {
                switch (itemToAdd.baseItem.gunItemReference.gunType)
                {
                    case EGunType.pistol:
                        itemSlot.transform.SetParent(pistolCatagory.transform);
                    break;
                    case EGunType.rifle:
                        itemSlot.transform.SetParent(rifleCatagory.transform);
                    break;
                    case EGunType.shotgun:
                        itemSlot.transform.SetParent(shotgunCatagory.transform);
                    break;
                    case EGunType.sniper:
                        itemSlot.transform.SetParent(sniperCatagory.transform);
                    break;
                    case EGunType.SMGs:
                        itemSlot.transform.SetParent(smgsCatagory.transform);
                    break;
                }
            }else if(itemToAdd.baseItem.armourItemReference)
            {
                switch (itemToAdd.baseItem.armourItemReference.armourType)
                {
                    case EArmourType.head:
                        itemSlot.transform.SetParent(pistolCatagory.transform);
                    break;
                    case EArmourType.chest:
                        itemSlot.transform.SetParent(rifleCatagory.transform);
                    break;
                    case EArmourType.legs:
                        itemSlot.transform.SetParent(shotgunCatagory.transform);
                    break;
                    case EArmourType.boots:
                        itemSlot.transform.SetParent(sniperCatagory.transform);
                    break;
                    case EArmourType.hand:
                        itemSlot.transform.SetParent(sniperCatagory.transform);
                    break;
                    case EArmourType.underArmour:
                        itemSlot.transform.SetParent(smgsCatagory.transform);
                    break;
                    case EArmourType.clothing:
                        itemSlot.transform.SetParent(smgsCatagory.transform);
                    break;
                }                
            }
            else if(itemToAdd.baseItem.explosiveItemReference)
            {
                itemSlot.transform.SetParent(explosivesCatagory.transform);
            }
            else if(itemToAdd.baseItem.ammoItemReference)
            {
                itemSlot.transform.SetParent(ammoCatagory.transform);
            }
            else if(itemToAdd.baseItem.medicalItemReference)
            {
                itemSlot.transform.SetParent(medicalCatagory.transform);
            }
            else if(itemToAdd.baseItem.junkItemReference)
            {
                itemSlot.transform.SetParent(junkCatagory.transform);
            }
            else if(itemToAdd.baseItem.miscItemReference)
            {
                itemSlot.transform.SetParent(miscCatagory.transform);
            }
            else if(itemToAdd.baseItem.notesItemReference)
            {
                itemSlot.transform.SetParent(notesCatagory.transform);
            }
            else if(itemToAdd.baseItem.medicalItemReference)
            {
                itemSlot.transform.SetParent(medicalCatagory.transform);
            }
#endregion
        }


        if(!itemToAdd.baseItem.stacks){
            GameObject itemSlot = Instantiate(itemDisplayPrefab);
            itemSlot.GetComponent<ItemSlotDisplay>().itemInSlot = itemToAdd;
            itemSlotDisplays.Add(itemSlot.GetComponent<ItemSlotDisplay>());
#region  adding types 
            if(itemToAdd.baseItem.gunItemReference)
            {
                switch (itemToAdd.baseItem.gunItemReference.gunType)
                {
                    case EGunType.pistol:
                        itemSlot.transform.SetParent(pistolCatagory.transform);
                    break;
                    case EGunType.rifle:
                        itemSlot.transform.SetParent(rifleCatagory.transform);
                    break;
                    case EGunType.shotgun:
                        itemSlot.transform.SetParent(shotgunCatagory.transform);
                    break;
                    case EGunType.sniper:
                        itemSlot.transform.SetParent(sniperCatagory.transform);
                    break;
                    case EGunType.SMGs:
                        itemSlot.transform.SetParent(smgsCatagory.transform);
                    break;
                }
            }else if(itemToAdd.baseItem.armourItemReference)
            {
                switch (itemToAdd.baseItem.armourItemReference.armourType)
                {
                    case EArmourType.head:
                        itemSlot.transform.SetParent(pistolCatagory.transform);
                    break;
                    case EArmourType.chest:
                        itemSlot.transform.SetParent(rifleCatagory.transform);
                    break;
                    case EArmourType.legs:
                        itemSlot.transform.SetParent(shotgunCatagory.transform);
                    break;
                    case EArmourType.boots:
                        itemSlot.transform.SetParent(sniperCatagory.transform);
                    break;
                    case EArmourType.hand:
                        itemSlot.transform.SetParent(sniperCatagory.transform);
                    break;
                    case EArmourType.underArmour:
                        itemSlot.transform.SetParent(smgsCatagory.transform);
                    break;
                    case EArmourType.clothing:
                        itemSlot.transform.SetParent(smgsCatagory.transform);
                    break;
                }                
            }
            else if(itemToAdd.baseItem.explosiveItemReference)
            {
                itemSlot.transform.SetParent(explosivesCatagory.transform);
            }
            else if(itemToAdd.baseItem.ammoItemReference)
            {
                itemSlot.transform.SetParent(ammoCatagory.transform);
            }
            else if(itemToAdd.baseItem.medicalItemReference)
            {
                itemSlot.transform.SetParent(medicalCatagory.transform);
            }
            else if(itemToAdd.baseItem.junkItemReference)
            {
                itemSlot.transform.SetParent(junkCatagory.transform);
            }
            else if(itemToAdd.baseItem.miscItemReference)
            {
                itemSlot.transform.SetParent(miscCatagory.transform);
            }
            else if(itemToAdd.baseItem.notesItemReference)
            {
                itemSlot.transform.SetParent(notesCatagory.transform);
            }
            else if(itemToAdd.baseItem.medicalItemReference)
            {
                itemSlot.transform.SetParent(medicalCatagory.transform);
            }
#endregion
        }
    }
}
