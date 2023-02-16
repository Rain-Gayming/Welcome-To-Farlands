using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;
    [Header("Pausing")]
    public bool paused;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    [Header("Gun Info")]
    public GameObject gunInfoUI;
    public TMP_Text gunInfoText;
    
    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableSettings());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused){
                MenuManager.instance.CloseAllMenus();
                paused = false;
                optionsMenu.GetComponentInParent<Menu>().open = false;
                pauseMenu.GetComponentInParent<Menu>().open = false;

            }else{
                MenuManager.instance.CloseAllMenus();
                paused = true;
                optionsMenu.GetComponentInParent<Menu>().open = false;
                pauseMenu.GetComponentInParent<Menu>().open = true;
            }
        }
    }

    public void OpenMenu()
    {
        pauseMenu.GetComponentInParent<Menu>().open = false;
        optionsMenu.GetComponentInParent<Menu>().open = true;
    }
    public IEnumerator EnableSettings()
    {
        optionsMenu.GetComponentInParent<Menu>().open = true;
        yield return new WaitForSeconds(0.1f);
        optionsMenu.GetComponentInParent<Menu>().open = false;
    }

    public IEnumerator GunInfoCo(string text, GunShooting gun, float time, bool stopsShooting)
    {
        gunInfoText.text = text;
        if(stopsShooting){
            gun.canShoot = false;
        }
        gunInfoUI.SetActive(true);
        yield return new WaitForSeconds(time);
        gun.canShoot = true;
        gunInfoUI.SetActive(false);
    }
}
