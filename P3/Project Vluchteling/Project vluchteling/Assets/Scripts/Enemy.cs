using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public List<GameObject> wp = new List<GameObject>();
    public float speed;
    public Transform target;
    public Transform player;
    public GameObject speler;
    public bool inRange;
    public int index;
    public int stopRange;
    public GameObject flash;
    public RaycastHit hit;
    public RaycastHit hut;
    public Ray ray;
    public bool obstructed;
    public float detectRate;
    public Rigidbody rb;
    public float stuckTimer;
    public static bool isHard;
    public float detCooldown;



    // Use this for initialization
    void Start() {
        index = 0;
        speed = 5;
        detectRate = 0.25F;
        flash.SetActive(false);
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update() {


        detectWalls();
        antiStuck();
        notAttacking();
        makeHarder();


    }

    void FixedUpdate()
    {
        patrol();
        movetoPlayer();



    }

    public void movetoPlayer()
    {
        if (inRange == true)
        {
            if (Vector3.Distance(transform.position, player.position) > stopRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                Vector3 targetDir = player.position - transform.position;
                Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetDir, speed, 0.0F);
                transform.rotation = Quaternion.LookRotation(lookDir);
                
            }

        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
            Attack();
        }
       
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    public void patrol()
    {
        if (inRange == false) {
            transform.position = Vector3.MoveTowards(transform.position, wp[index].transform.position, speed * Time.deltaTime);
            target = wp[index].transform;
            Vector3 targetDir = target.position - transform.position;
            Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetDir, speed, 0.0F);
            transform.rotation = Quaternion.LookRotation(lookDir);
            if (index < wp.Count)
            {
                if (transform.position == wp[index].transform.position)
                {
                    index++;
                }
            }
            if (index == wp.Count)
            {
                index = 0;
            }
        }
    }

    public void Attack()
    {
        if (obstructed == false)
        {
            if (inRange == true)
            {

                flash.SetActive(true);
                Player.detection += detectRate;
                
            }
   
        }


    }

    public void notAttacking()
    {
        if (inRange == false)
        {
            flash.SetActive(false);
            detCooldown += Time.deltaTime;
            if(detCooldown >= 15)
            {
                Player.detection = 0;
                detCooldown = 0;
            }
            
        }
        
    }

    public void detectWalls()
    {


        if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            if (hit.transform.tag != "Player")
            {
                obstructed = true;
            }
            else if (hit.transform.tag == "Player")
            {
                obstructed = false;
            }
        }
    }

    public void antiStuck()
    {
        if (obstructed == true)
        {
            
            stuckTimer += Time.deltaTime;
            if (stuckTimer >= 20)
            {
                transform.position = wp[0].transform.position;
                stuckTimer = 0;
                obstructed = false;
                index = 0;
            }
        }
        
    }

    public void makeHarder() //( ͡° ͜ʖ ͡°)
    {
        if(isHard == true)
        {
            speed = 6;
            detectRate = 1;
        }
    }
}


   





