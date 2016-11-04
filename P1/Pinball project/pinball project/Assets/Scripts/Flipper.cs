using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour
{

    public bool activateFlipper;
    public bool deActivateFlipper;
    public float activateTimer = 0f;
    public float deActivateTimer = 0f;
    public GameObject flipperPivot;
    public static bool ismovingright = false;
    public Quaternion originalRotation;

    void Start() //Kijk voor commentaar bij Flipperlinks dit script is exact hetzelfde behalve de input
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {

        if (Input.GetButtonDown("Right"))
        {
            
            ismovingright = true;
        }
        if (Input.GetButtonDown("Right"))
        {
            activateFlipper = true;
            
        }

        if (activateTimer > 0.06f)
        {
            activateFlipper = false;
            activateTimer = 0f;

        }

        if (activateFlipper)
        {
            transform.RotateAround(transform.position, flipperPivot.transform.up, 800 * Time.deltaTime);
            activateTimer = activateTimer + Time.deltaTime;
        }

        if (Input.GetButtonUp("Right"))
        {
            deActivateFlipper = true;
            ismovingright = false;
        }

        if (deActivateTimer > 0.06f)
        {
            deActivateFlipper = false;
            deActivateTimer = 0f;

        }

        if (deActivateFlipper)
        {
            
            transform.rotation = originalRotation;
            deActivateTimer = deActivateTimer + Time.deltaTime;
        }
    }
}