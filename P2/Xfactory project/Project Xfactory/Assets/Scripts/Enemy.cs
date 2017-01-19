using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {
    public Transform playerpos;
    public GameObject player;
    public float turnspeed;
    public float speed;
    public GameObject bulletemitter;
    public GameObject bullet;
    public float bulletspeed;
    public bool canshoot;
    public float health;
    public float ammodropchance;
    public GameObject ammobox;
    public bool isquitting;
    public float points;
    
    
    // Use this for initialization
    void Start () {
        canshoot = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        hps();
        
        
    }

     void OnTriggerStay(Collider other)
    {
       
        if(other.gameObject.name == "Player")
        {
            
            rotation();
            movement();
            if (canshoot == true)
            {
                shooting();
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bullet(Clone)")
        {
            health = health - 10;
        }
    }

    public void rotation()
    {
        Vector3 targetdir = playerpos.position - transform.position;
        float step = turnspeed * Time.deltaTime;
        Vector3 newdir = Vector3.RotateTowards(transform.forward, targetdir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newdir);
    }

    public void movement()
    {
        float step2 = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerpos.position, step2);
    }

    public void shooting()
    {
        GameObject tempbullethandler;
        tempbullethandler = Instantiate(bullet, bulletemitter.transform.position, bulletemitter.transform.rotation) as GameObject;
        Rigidbody temprigid = tempbullethandler.GetComponent<Rigidbody>();
        temprigid.AddForce(transform.forward * bulletspeed);
        Destroy(tempbullethandler, 4.0F);
        canshoot = false;
        StartCoroutine("waitthreeseconds");
        if (Secretenemy.ispingu == true)
        {
            Secretenemy secretenemy = gameObject.GetComponent<Secretenemy>();
            secretenemy.nood();
        }
       
        
    }

    public void hps()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }

    IEnumerator waitthreeseconds()
    {
        yield return new WaitForSeconds(2);
        canshoot = true;
    }

    void OnApplicationQuit()
    {
        isquitting = true;
    }


    void OnDestroy()
    {
        Score.score = Score.score + points;
        if (!isquitting)
        {
            if (UnityEngine.Random.value > ammodropchance)
            {
                Instantiate(ammobox, gameObject.transform.position, gameObject.transform.rotation);
            }
        }
    }
}
