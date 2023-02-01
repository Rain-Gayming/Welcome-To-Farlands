using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public Animator anim;
    public GunStats info;
    public EFireMode currentFireMode;
    public Transform shootPoint;
    public bool equipped = true;
    float fireTime;
    int ammo;
    public bool canShoot = true;
    bool running;
    bool shooting;
    // Start is called before the first frame update
    void Start()
    {
        ammo = info.maxAmmo;
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!InGameManager.instance.paused && equipped){
            fireTime -= Time.deltaTime;

            anim.SetLayerWeight(info.animationLayer, 1);

            running = PlayerMovement.instance.running;


            if(canShoot && !PlayerMovement.instance.moving && ammo > 0){
                if(InputManager.instance.shooting){
                    if(fireTime <= 0){
                        RaycastHit hit;
                        if(Physics.Raycast(shootPoint.position, shootPoint.forward, out hit ,info.range)){
                            Debug.Log(hit.point);
                        }
                        anim.SetBool("Shooting", true);
                        shooting = true;
                        ammo--;
                        fireTime = info.fireRate;
                        if(currentFireMode == EFireMode.single){
                            InputManager.instance.shooting = false;
                        }
                    }
                }else{
                    anim.SetBool("Shooting", false);
                    shooting = false;                    
                }                
            }else{
                anim.SetBool("Shooting", false);
                shooting = false;                    
            }
            
            if(InputManager.instance.aiming){
                anim.SetBool("Aiming", true);
            }else{
                anim.SetBool("Aiming", false);
            }
        
            if(InputManager.instance.reloading && !running && !shooting){
                StartCoroutine(ReloadCo());
            }

            if(InputManager.instance.checkAmmo){
                anim.SetBool("Ammo Checking", true);
                StartCoroutine(InGameManager.instance.GunInfoCo(ammo.ToString(), this));
            }else{
                anim.SetBool("Ammo Checking", false);                
            }

            if(InputManager.instance.changeFireMode){
                
                switch (currentFireMode)
                {
                    case EFireMode.single:
                        if(info.canBeAutomatic){
                            currentFireMode = EFireMode.automatic;
                            InputManager.instance.changeFireMode = false;
                        }
                    break;
                    case EFireMode.automatic:
                        currentFireMode = EFireMode.single;
                            InputManager.instance.changeFireMode = false;
                    break;
                }       
                
            }
        }
    }

    public IEnumerator ReloadCo()
    {
        canShoot = false;
        anim.SetBool("Reloading", true);
        yield return new WaitForSeconds(info.reloadTime);
        ammo = info.maxAmmo;
        canShoot = transform;
        anim.SetBool("Reloading", false);
    }
}


