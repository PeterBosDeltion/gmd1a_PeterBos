using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        destroyStuff();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destroyStuff()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("ammobox");
        for (int i = 0; i < boxes.Length; i++)
            Destroy(boxes[i]);
    }
}
