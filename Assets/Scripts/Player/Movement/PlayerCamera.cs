using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera instance;



    public float mouseSensitvityX;
    public float mouseSensitvityY;
    public Transform playerBody;
    float xRotation = 0f;

    public bool paused;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        paused = InGameManager.instance.paused;
        if(!paused){
            
            float mouseX = InputManager.instance.looking.x * mouseSensitvityX * Time.deltaTime;
            float mouseY = InputManager.instance.looking.y * mouseSensitvityY * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80, 80);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else{            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
