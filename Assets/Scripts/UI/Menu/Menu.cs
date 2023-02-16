using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool open;
    public bool hasBackTab;
    public string menuName;
    public GameObject relatedMenu;
    public GameObject backTab;

    private void Start(){
        StartCoroutine(StartCo());
    }
    private void Update() 
    {
        relatedMenu.SetActive(open);
        if(Input.GetKeyDown(KeyCode.Tab) && hasBackTab && open){
            backTab.GetComponent<Menu>().open = true;
            open = false;
        }
    }
    public IEnumerator StartCo()
    {
        open = true;
        yield return new WaitForSeconds(0.1f);
        open = false;
    }
}
