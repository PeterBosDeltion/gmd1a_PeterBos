using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lol : MonoBehaviour {
    public GameObject brief;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            brief.SetActive(true);
        }
	}
}
