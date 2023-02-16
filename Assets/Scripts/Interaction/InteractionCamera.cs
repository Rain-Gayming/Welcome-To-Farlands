using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCamera : MonoBehaviour
{
    public float range;
    public Transform interactFrom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(interactFrom.position, interactFrom.forward, out hit, range)){
            if(hit.transform.GetComponent<ItemInteractable>()){
                if(InputManager.instance.interact){
                    hit.transform.GetComponent<ItemInteractable>().Interact();
                }
                MenuManager.instance.interactionUI.SetActive(true);
                MenuManager.instance.interactionName.text = hit.transform.GetComponent<ItemInteractable>().itemToAdd.baseItem.itemName;
                MenuManager.instance.interactionText.text = "E) Pick Up " + hit.transform.GetComponent<ItemInteractable>().itemToAdd.baseItem.itemName;
            }else{
                MenuManager.instance.interactionUI.SetActive(false);
            }
        }else{
            MenuManager.instance.interactionUI.SetActive(false);
        }
    }
}
