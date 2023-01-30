using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<Menu> menus;
    public string thisMainName;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < menus.Count; i++)
        {
            if(menus[i].menuName == thisMainName){
                menus[i].open = true;
            }else{
                menus[i].open = false;
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].open = false;
        }
        menu.open = true;
    }
}
