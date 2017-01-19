using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammobox : MonoBehaviour {
    public GameObject player;
    public int ammodropped;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
            Shoot.ammo = Shoot.ammo + ammodropped;
            Destroy(gameObject);
        }
    }
}
