using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secretenemy : MonoBehaviour {
    public static bool ispingu;
    public static AudioClip noot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ispingu = true;

	}

    public void nood()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Play(0);
    }
}
