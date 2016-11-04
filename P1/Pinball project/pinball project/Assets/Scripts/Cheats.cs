using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Cheats : MonoBehaviour {
    public string input= "";
    public InputField putin;
    public GameObject gold;
    public GameObject cam;
    public Vector3 goldteleport;
    public GameObject startaudio;
    public GameObject pokgo;
    public AudioSource loser;
    public GameObject Image;
    public GameObject monster;
    // Use this for initialization
    void Start () {
        putin.onEndEdit.AddListener(delegate { LockInput(putin); }); //Add een listener voor de submitfield
        Image.SetActive(false); //Zet een gameobject naar niet actief
    }
	
	// Update is called once per frame
	void Update () {
	   
	}
    void LockInput(InputField input)
    {
      if(input.text == "Potvis")
        {
            Ballscript.HP = Ballscript.HP + 1; //+1 leven
        }
        if (input.text == "Dagobert")
        {
           Score.points = Score.points *2; //Verdubbelt de huidige score
        }
        if (input.text == "Kingofthelosers") 
        {
            Castle.HP = 0; //Vernietigd het kasteel meteen
            loser.GetComponent<AudioSource>().Play(); //Speelt een leuk geluid
        }
        if (input.text == "waaromzoujeditdoen")
        {
            Score.points = 0; //Reset de score
        }
        if (input.text == "Harambe")
        {
           
            Image.SetActive(true); //Weergeeft een afbeelding
        }
        if (input.text == "Superbump")
        {
            Bumper.bumpspeed = 100; //Verhoogt de bumpspeed van alle bumpers
        }
        if (input.text == "Ytho")
        {
            cam.transform.Rotate(Vector3.forward *180); //Flipt de camera ondersteboven
        }
        if (input.text == "Pokemongo")
        {

            startaudio.SetActive(false); //Zet de achtergrondmuziek uit
            pokgo.SetActive(true); //Begint met een irritant liedje spelen

        }

        if (input.text == "Killme")
        {

            Ballscript.HP = 0 - 1; //Verlies meteen al je levens

        }
        if (input.text == "Spaghettimonster")
        {

            monster.SetActive(true); //Weergeeft een afbeelding
            
            


        }

    }
}
