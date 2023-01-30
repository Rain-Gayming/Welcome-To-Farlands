using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [Header("Settings")]
    public float xSensitivity;
    public float ySensitivity;

    private void Awake() {
        if(instance){
            Destroy(instance.gameObject);
            instance = this;
        }else{
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerCamera.instance){
            PlayerCamera.instance.mouseSensitvityX = xSensitivity;
            PlayerCamera.instance.mouseSensitvityY = ySensitivity;
        }
    }
}
