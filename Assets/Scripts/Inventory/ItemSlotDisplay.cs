using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSlotDisplay : MonoBehaviour, IPointerClickHandler
{
    public Item itemInSlot;
    public Image itemIcon;
    public GameObject equippedIcon;
    public bool equipped;
    public TMP_Text itemText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(itemInSlot.baseItem)
        {
            itemIcon.gameObject.SetActive(true);
            itemIcon.sprite = itemInSlot.baseItem.icon;
            if(itemInSlot.amount > 1){
                itemText.text = itemInSlot.baseItem.itemName + " (" + itemInSlot.amount.ToString() + ")"; 
            }else{
                itemText.text = itemInSlot.baseItem.itemName; 
            }
        }else{
            Destroy(gameObject);
        }

        equippedIcon.SetActive(equipped);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(equipped){
            equipped = false;            
            if(itemInSlot.baseItem.armourItemReference){
                switch (itemInSlot.baseItem.armourItemReference.armourType)
                {
                    case EArmourType.head:
                        EquipmentManager.instance.headItem = null;
                    break;
                    case EArmourType.chest:
                        EquipmentManager.instance.chestItem = null;
                    break;
                    case EArmourType.legs:
                        EquipmentManager.instance.legsItem = null;
                    break;
                    case EArmourType.boots:
                        EquipmentManager.instance.bootsItem = null;
                    break;
                    case EArmourType.clothing:
                        EquipmentManager.instance.clothingItem = null;
                    break;
                    case EArmourType.underArmour:
                        EquipmentManager.instance.underArmourItem = null;
                    break;
                }
            }

            if(itemInSlot.baseItem.gunItemReference){
                EquipmentManager.instance.gunItem = null;
                Destroy(EquipmentManager.instance.gunItemObj);
            }

            if(itemInSlot.baseItem.ammoItemReference){
                EquipmentManager.instance.ammoItem = null;
            }        

            if(itemInSlot.baseItem.meleeItemReference){
                EquipmentManager.instance.meleeWeapon = null;
            }
        }else{
            equipped = true;
            if(itemInSlot.baseItem.armourItemReference){
                switch (itemInSlot.baseItem.armourItemReference.armourType)
                {
                    case EArmourType.head:
                        EquipmentManager.instance.headItem = itemInSlot;
                    break;
                    case EArmourType.chest:
                        EquipmentManager.instance.chestItem = itemInSlot;
                    break;
                    case EArmourType.legs:
                        EquipmentManager.instance.legsItem = itemInSlot;
                    break;
                    case EArmourType.boots:
                        EquipmentManager.instance.bootsItem = itemInSlot;
                    break;
                    case EArmourType.clothing:
                        EquipmentManager.instance.clothingItem = itemInSlot;
                    break;
                    case EArmourType.underArmour:
                        EquipmentManager.instance.underArmourItem = itemInSlot;
                    break;
                }
            }

            if(itemInSlot.baseItem.gunItemReference){
                EquipmentManager.instance.gunItem = itemInSlot;
                EquipmentManager.instance.UpdateWeapon();
            }

            if(itemInSlot.baseItem.ammoItemReference){
                EquipmentManager.instance.ammoItem = itemInSlot;
            }        

            if(itemInSlot.baseItem.meleeItemReference){
                EquipmentManager.instance.meleeWeapon = itemInSlot;
            }
        }
    }
}
