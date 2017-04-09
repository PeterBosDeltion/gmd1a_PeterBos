using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public float movementspeed = 5.0F;
    public float mousesensitivity = 5.0F;
    public float updownrange = 60.0F;
    float verticalRotation = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    public void movement()
    {
        //Rotation


        float rotLeftRight = Input.GetAxis("Mouse X") * mousesensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mousesensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -updownrange, updownrange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);


        //Movement
        float forwardspeed = Input.GetAxis("Vertical") * movementspeed;
        float sidespeed = Input.GetAxis("Horizontal") * movementspeed;

        Vector3 speed = new Vector3(sidespeed, 0, forwardspeed);

        speed = transform.rotation * speed;

        CharacterController cc = GetComponent<CharacterController>();

        if (Input.GetButton("shift"))
        {
            movementspeed = 8;
        }
        else if (Input.GetButtonUp("shift"))
        {
            movementspeed = 5;
        }

        cc.SimpleMove(speed);
    }
}
