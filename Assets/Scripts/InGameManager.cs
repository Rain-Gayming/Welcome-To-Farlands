using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;
    [Header("Pausing")]
    public bool paused;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

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
            paused = !paused;
            optionsMenu.GetComponentInParent<Menu>().open = false;
            pauseMenu.GetComponentInParent<Menu>().open = paused;
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
        yield return new WaitForEndOfFrame();
        optionsMenu.GetComponentInParent<Menu>().open = false;
    }
}
