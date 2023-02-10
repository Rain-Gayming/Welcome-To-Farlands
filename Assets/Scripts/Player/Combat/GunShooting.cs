using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public Recoil recoil;
    public Animator anim;
    public GunStats info;
    public GameObject impact;
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
        recoil = GetComponentInParent<Recoil>();
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
                        Instantiate(impact, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(hit.normal, Vector3.up) * impact.transform.rotation);
                        recoil.RecoilFire();
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
                recoil.recoilX = info.aimRecoilX;
                recoil.recoilY = info.aimRecoilY;
                recoil.recoilZ = info.aimRecoilZ;
                recoil.snappiness = info.snappiness;
                recoil.returnSpeed = info.returnSpeed;
            }else{
                anim.SetBool("Aiming", false);
                recoil.recoilX = info.pointFireRecoilX;
                recoil.recoilY = info.pointFireRecoilY;
                recoil.recoilZ = info.pointFireRecoilZ;
                recoil.snappiness = info.snappiness;
                recoil.returnSpeed = info.returnSpeed;
            }
        
            if(InputManager.instance.reloading && !running && !shooting){
                StartCoroutine(ReloadCo());
            }

            if(InputManager.instance.checkAmmo){
                anim.SetBool("Ammo Checking", true);
                StartCoroutine(InGameManager.instance.GunInfoCo(ammo.ToString(), this));
                StartCoroutine(CheckGunCo());
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
        canShoot = true;
        anim.SetBool("Reloading", false);
    }
    public IEnumerator CheckGunCo()
    {
        canShoot = false;
        anim.SetBool("Ammo Checking", true);
        yield return new WaitForSeconds(3f);
        canShoot = true;
        anim.SetBool("Ammo Checking", false);    
    }
}


