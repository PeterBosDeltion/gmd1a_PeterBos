using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galg : MonoBehaviour {
    public GameObject player;
    public GameObject hangpos;
    public GameObject ui;
    public bool hanged;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        hangin();
	}

    public void hangin()
    {
        if(hanged == true)
        {

            StartCoroutine("waittwoseconds");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ui.SetActive(true);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if (Input.GetButtonDown("E"))
            {
                hanged = true;
                Rigidbody playerrigid = player.GetComponent<Rigidbody>();
                CharacterController playercontrol = player.GetComponent<CharacterController>();
                playerrigid.useGravity = false;
                playercontrol.enabled = false;
                player.transform.position = hangpos.transform.position;
                ui.SetActive(false);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ui.SetActive(false);
        }
    }

    IEnumerator waittwoseconds()
    {
        yield return new WaitForSeconds(20);
        Playerhp.health = Playerhp.health - 9999999;
        

    }
}
