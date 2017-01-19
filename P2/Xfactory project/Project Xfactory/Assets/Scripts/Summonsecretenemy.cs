using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summonsecretenemy : MonoBehaviour {
    public AudioClip noot;
    public int noots;
    public int requirednoots;
    public static bool done;
	// Use this for initialization
	void Start () {
        noots = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(noots >= requirednoots)
        {
            done = true;
        }
	}

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("E"))
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play(0);
            noots = noots + 1;


        }
    }
}
