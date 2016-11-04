using UnityEngine;
using System.Collections;
using UnityEngine.UI;

 public class Ballscript : MonoBehaviour {
    public static bool extralife = false;
    public static int HP = 3;
    public Rigidbody rb;
    public Vector3 direction;
    public float repelspeed;
    public bool ismovingright;
    public bool ismovingleft;
    public Text Lives;
    public float launchspeed;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        ismovingleft = Flipperlinks.ismovingleft; //Checkt of de flipper beweegt
        ismovingright = Flipper.ismovingright;//Checkt of de flipper beweegt
        Lives.text = "Lives:  " + HP; //Zet de text naar het aantal levens dat je hebt
       
        
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Castle2") //Als de bal het kasteel raakt
        {
            if (Castle.onfire == false) //Checkt of je al gewonnen hebt
            {
                HP = HP + 1; //Telt een leven erbij op
            }
        }
        if (col.gameObject.name == "Flipperright") //Als de bal de flipper raakt
        {
            if (ismovingright == true) //Checkt of de flipper beweegt
            {
                direction = col.contacts[0].point; //Pakt de positie van de bal

                rb.AddForce(direction * -repelspeed); //Stoot de bal weg
            }
        }
        if (col.gameObject.name == "Flipperleft") //Hetzelfde commentaar dat hierboven staat geld hier ook
        {
            if (ismovingleft == true)
            {
                direction = col.contacts[0].point;

                rb.AddForce(direction * -repelspeed);
            }

        }

    }
    public void OnDestroy()
    {
        HP = HP - 1; //Als de bal word vernietigd gaat er een leven vanaf
    }
}
