using UnityEngine;
using System.Collections;

public class Launchgate : MonoBehaviour {
    public Vector3 orignalpos;
    public Vector3 upos;
	// Use this for initialization
	void Start () {
        orignalpos = transform.position; //Pakt de startpositie van de gate

	}
	
	// Update is called once per frame
	void Update () {
        gateup();
	}
    public void gateup()
    {
        if (Input.GetButtonDown("Jump"))
        {
            transform.position = upos; //Doet de gate omhoog
        }
        if (Input.GetButtonUp("Jump"))
        {
            transform.position = orignalpos; // Doet de gate weer omlaag
        }
    }
}
