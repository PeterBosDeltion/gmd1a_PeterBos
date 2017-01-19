using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    public float movementspeed = 5.0F;
    public float mousesensitivity = 5.0F;
    public float updownrange = 60.0F;
    float verticalRotation = 0;
    public Camera main;
    public float sprintspeed = 15.0F;
    public Vector3 startpos;
    
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
    }
	
	// Update is called once per frame
	void Update () {

        //Rotation

        float rotLeftRight = Input.GetAxis("Mouse X") * mousesensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mousesensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -updownrange, updownrange);
        main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);


        //Movement
        float forwardspeed = Input.GetAxis("Vertical") * movementspeed;
        float sidespeed = Input.GetAxis("Horizontal") * movementspeed;
        


        Vector3 speed = new Vector3(sidespeed, 0, forwardspeed);

        speed = transform.rotation * speed;

        CharacterController cc = GetComponent<CharacterController>();

        cc.SimpleMove(speed);

        //Sprint
        if (Shoot.cansprint == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementspeed = sprintspeed;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementspeed = 5.0F;
        }

        unstuck();
        
       

	}

    public void unstuck()
    {
        if (Input.GetButtonDown("Q"))
        {

            gameObject.transform.position = startpos;
            
        }
    }
}
