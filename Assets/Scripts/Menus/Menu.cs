using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool open;
    public string menuName;
    public GameObject relatedMenu;

    private void Update() 
    {
        relatedMenu.SetActive(open);
    }
}
