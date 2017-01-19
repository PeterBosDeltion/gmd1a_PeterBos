using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Shoot : MonoBehaviour {
    public GameObject bullet;
    public GameObject bulletemitter;
    public GameObject bulletemitter2;
    public float bulletspeed;
    public static float ammo;
    public  Text ammodisplay;
    public  float chamberammo;
    public bool canreload;
    public GameObject standardpos;
    public GameObject aimpos;
    public float reloadtimer;
    public Animation anim;
    public AnimationClip shooting;
    public AnimationClip scopedshoot;
    public bool canshoot;
    public bool isdone;
    public bool scoped;
    public AnimationClip sprint;
    public static bool cansprint;
    public bool isdonesprint;



    public AnimationClip reloadzing;
    
    
	// Use this for initialization
	void Start () {
        isdone = true;
        isdonesprint = true;
        cansprint = true;
        canshoot = true;
        ammo = 100;
        chamberammo = 2;
        canreload = false;
        ammodisplay.text = chamberammo + "/" + ammo;
        anim.AddClip(reloadzing, "reloading");
        anim.AddClip(scopedshoot, "scopeshot");
        anim.AddClip(sprint, "sprint");
        transform.position = standardpos.transform.position;


    }
	
	// Update is called once per frame
	void Update () {
      
        animu();
        shoot();
        reload();
        aim();
        if (isdone == true)
        {
            canshoot = true;
            cansprint = true;
            isdone = false;
        }
     

        ammodisplay.text = chamberammo + "/" + ammo;
       
    }

    public void shoot()
    {
        if(canshoot == true) { 
        if (Input.GetMouseButtonDown(0))
        {

                //Barrel 1
                if (chamberammo > 0)
                {
                    GameObject tempbullethandler;
                    tempbullethandler = Instantiate(bullet, bulletemitter.transform.position, bulletemitter.transform.rotation) as GameObject;
                    Rigidbody temprigid = tempbullethandler.GetComponent<Rigidbody>();
                    temprigid.AddForce(transform.right * bulletspeed);
                    Destroy(tempbullethandler, 4.0F);
                    chamberammo = chamberammo - 1;

                    //Barrel 2
                    GameObject tempbullethandler2;
                    tempbullethandler2 = Instantiate(bullet, bulletemitter2.transform.position, bulletemitter2.transform.rotation) as GameObject;
                    Rigidbody temprigid2 = tempbullethandler2.GetComponent<Rigidbody>();
                    temprigid2.AddForce(transform.right * bulletspeed);
                    Destroy(tempbullethandler2, 4.0F);
                    chamberammo = chamberammo - 1;

                    AudioSource audio = GetComponent<AudioSource>();
                    anim = GetComponent<Animation>();
                    anim.AddClip(shooting, "Shoot");
                    if(scoped == true)
                    {
                        anim.Play("scopeshot");
                       
                    }
                    if (scoped == false)
                    {
                        anim.Play("Shoot");
                    }
                    audio.Play(0);


                    
                    
                }
                

                //Set ammo display text
                ammodisplay.text = chamberammo + "/" + ammo;
            }
           
            
        }
    }

    public void reload()
    {
        if(canreload == true) {
            if (Input.GetKeyDown("r"))
            {
                anim.AddClip(reloadzing, "reloading");
                anim.Play("reloading");
                ammo = ammo - 2;
                if (ammo >= 0)
                {
                    chamberammo = 2;
                    ammodisplay.text = chamberammo + "/" + ammo;
                    canreload = false;
                    
                    

                }
            }
            
          
        }
        if (chamberammo == 0)
        {
            canreload = true;
        }
        if (ammo <= 0)
        {
            canreload = false;
        }
      
    }

    public void aim()
    {
        if (Input.GetMouseButton(1))
        {
            transform.position = aimpos.transform.position;
            scoped = true;
           
        }
        if (Input.GetMouseButtonUp(1))
        {
            transform.position = standardpos.transform.position;
            scoped = false;
            
        }
    }

    public void animu()
    {
        if (anim.IsPlaying("Shoot"))
        {
            canreload = false;
            cansprint = false;
            isdone = true;
          

        }
        if (anim.IsPlaying("reloading"))
        {
            canshoot = false;
            cansprint = false;
            isdone = true;
            

        }
        if (anim.IsPlaying("sprint"))
        {
            canshoot = false;
            canreload = false;
            isdone = true;

        }
        if (cansprint == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.Play("sprint");
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.Stop("sprint");
            transform.position = standardpos.transform.position;
            transform.rotation = standardpos.transform.rotation;
        }
    }
}
