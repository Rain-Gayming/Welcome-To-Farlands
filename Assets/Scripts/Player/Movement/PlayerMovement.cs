using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    CharacterController controller;
    public Animator anim;
    public bool paused;

    [Header("Walking Running")]
    public float walkSpeed;
    public float runSpeed;
    float stamina;
    float maxStamina = 100;
    public float staminaRecoveryMultiplier = 1;
    float weight;
    float speed;
    [HideInInspector]public bool running;
    [HideInInspector]public bool moving;
    public Vector2 inputVal;

    [Header("Jumping")]
    public float jumpHeight;
    bool isGrounded;
    float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 velocity;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        paused = InGameManager.instance.paused;
        if(!paused){
            inputVal.x = InputManager.instance.walking.x;
            inputVal.y = InputManager.instance.walking.y;

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if(isGrounded && velocity.y < 0){
                velocity.y = -2f;
            }
            if(inputVal != Vector2.zero){
                moving = true;
            }else{
                moving = false;                   
            }

            if(InputManager.instance.sprinting && stamina > 0){
                if(inputVal != Vector2.zero){
                    anim.SetBool("Running", true);
                    speed = runSpeed;
                    stamina -= Time.deltaTime * 2.5f;
                    running = true;
                }else{
                    speed = walkSpeed;
                    anim.SetBool("Running", false);
                    if(stamina > maxStamina){
                        stamina += Time.deltaTime * 2 * staminaRecoveryMultiplier;
                    }
                    running = false;                   
                }
            }else{
                speed = walkSpeed;
                anim.SetBool("Running", false);
                if(stamina > maxStamina){
                    stamina += Time.deltaTime * 2 * staminaRecoveryMultiplier;
                }
                running = false;
            }
            
            if(inputVal != Vector2.zero){
                anim.SetBool("Walking", true);
            }else{
                anim.SetBool("Walking", false);
            }

            if(InputManager.instance.jumping && isGrounded){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            Vector3 move = transform.right * inputVal.x + transform.forward * inputVal.y;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
