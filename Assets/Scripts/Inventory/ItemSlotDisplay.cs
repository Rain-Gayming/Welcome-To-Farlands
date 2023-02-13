using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotDisplay : MonoBehaviour
{
    public Item itemInSlot;
    public Image itemIcon;
    public TMP_Text amountText;

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
                amountText.gameObject.SetActive(true);
                amountText.text = itemInSlot.amount.ToString();
            }else{
                amountText.gameObject.SetActive(false);
            }
        }else{
            itemIcon.gameObject.SetActive(false);
        }
    }
}
