using UnityEngine;
using System.Collections;

public class Fliprechts : MonoBehaviour
{
    public Rigidbody rb2;
    // Use this for initialization
    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            rb2.AddForce(transform.forward * 500);
            transform.Rotate(transform.rotation.x +0, transform.rotation.y +0, transform.rotation.z + 90);
        }
        else if (Input.GetKeyUp("right"))
        {
            rb2.AddForce(transform.forward * -500);
            transform.Rotate(transform.rotation.x -0, transform.rotation.y -0, transform.rotation.z - 90);
        }

    }
}