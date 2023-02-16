using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public List<Menu> menus;
    public string thisMainName;

    public GameObject interactionUI;
    public TMP_Text interactionName;
    public TMP_Text interactionText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        for (int i = 0; i < menus.Count; i++)
        {
            if(menus[i].menuName == thisMainName){
                menus[i].open = true;
            }else{
                menus[i].open = false;
            }
        }
    }

    private void Update() {
        /*for (int i = 0; i < menus.Count; i++)
        {
            if(menus[i].menuName == "Pause"){
                menus[i].open = InGameManager.instance.paused;
            }
        }*/
    }

    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].open = false;
        }
        menu.open = true;
    }

    public void CloseAllMenus()
    {
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].open = false;
        }
    }
}
