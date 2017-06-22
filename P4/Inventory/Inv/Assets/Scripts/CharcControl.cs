using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcControl : MonoBehaviour {
    public float moveSpeed;
    public float mousesensitivity = 5.0F;
    public float updownrange = 60.0F;
    float verticalRotation = 0;
   // public static Animator anim;
    // Use this for initialization
    void Start () {
        //Character controller is hier als herkansing voor Periode 2
        //Volgens u zou je hiervoor een voldoende krijgen voor P2
        //Ik weet wel dat het geen physics volgt en dat je daarvoor een rigidbody moet gebruiken

        //Animation was voor een ander project
        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        MouseLook();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
        //anim.SetBool("moving",  true);
        }
        else
        {
            //anim.SetBool("moving", false);
        }
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            StartCoroutine(FearAnim());
        }
    }

    IEnumerator FearAnim()
    {
        //anim.SetBool("beingSeen", true);
        yield return new WaitForSeconds(0.9F);
        //anim.SetBool("beingSeen", false);
    }

    void MouseLook()
    {
        float rotLeftRight = Input.GetAxis("Mouse X") * mousesensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mousesensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -updownrange, updownrange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
