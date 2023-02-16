using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItemAdd : MonoBehaviour
{
    public Item itemToAdd;
    public KeyCode myKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(myKey)){
            Inventory.instance.AddItem(itemToAdd);
        }
    }
}
