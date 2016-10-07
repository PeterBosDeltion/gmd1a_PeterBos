using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Launch();
	}
    public void Launch()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.forward *-4000); 
        } else if (Input.GetKeyUp("space"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = new Vector3(3.98F, 0.56F, -17.28F);
        }
    }
}
