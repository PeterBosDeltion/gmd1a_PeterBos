using UnityEngine;
using System.Collections;

public class Flipperlinks : MonoBehaviour
{

    public bool activateFlipper;
    public bool deActivateFlipper;
    public float activateTimer = 0f;
    public float deActivateTimer = 0f;
    public GameObject flipperPivot;
    public static bool ismovingleft = false;
    public Quaternion originalRotation;

    void Start() //Hetzelfde commentaar geld voor het "Flipper" Script
    {
        originalRotation = transform.rotation; // Pakt de originele rotation van de flipper als de scene start
    }

    void Update()
    {

        if (Input.GetKeyDown("left")) //Dit script gebruikt getkey omdat button raar deed met de launchgate
        {

            ismovingleft = true; //Zet de bool om the checken of de bal force krijgt aan
        }
        if (Input.GetKeyDown("left"))
        {
            activateFlipper = true; //Activeerd de timer
        }

        if (activateTimer > 0.06f)
        {
            activateFlipper = false; //Als de timer naar deze tijd heeft opgeteld gaat de timer weer uit
            activateTimer = 0f; //En de timer word gereset
           

        }

        if (activateFlipper) //Als de timer aan is
        {
            transform.RotateAround(transform.position, flipperPivot.transform.up, -800 * Time.deltaTime); //Draait de flipper
            activateTimer = activateTimer + Time.deltaTime; //Telt meer bij de timer op
        }

        if (Input.GetKeyUp("left"))
        {
            deActivateFlipper = true; // Zet de flipper uit
            ismovingleft = false; //Zet de bool uit waardoor force word ge-add bij de bal
        }

        if (deActivateTimer > 0.06f)
        {
            deActivateFlipper = false; // Zet de flipper uit
            deActivateTimer = 0f; //Reset de timer

        }

        if (deActivateFlipper) //Als deActivateflipper aan staat
        {
           
            transform.rotation = originalRotation; //Reset de rotation van de flipper naar de originele rotation
            deActivateTimer = deActivateTimer + Time.deltaTime; //Telt iets bij de timer op
        }
    }
}