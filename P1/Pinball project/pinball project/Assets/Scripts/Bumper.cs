using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{
    public Vector3 direction;
    public static int bumpspeed = 60;
    public float points;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bal(Clone)")
        {
            direction = col.contacts[0].point;  //pakt de positie van de bal als hij collided
            col.rigidbody.AddForce(direction * -bumpspeed); // stoot de bal weg
            Score.points = Score.points + 100; // telt 100 punten bij de score op
        } 
        if (col.gameObject.name == "Bal")   //Zie hierboven
        {
            direction = col.contacts[0].point;  
            col.rigidbody.AddForce(direction * -bumpspeed);
            Score.points = Score.points + 100;
        }
    }
}
