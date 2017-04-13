using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour {
    public static bool hasMap;
    public static bool hasPickup;
    public GameObject winCanv;
    public GameObject loseCanv;
   
	// Use this for initialization
	void Start ()
    {
        Npc.veryPissed = false;
        winCanv.SetActive(false);
        loseCanv.SetActive(false);
        Player.detection = 0;
        hasMap = false;
        hasPickup = false;
        Questmanager.completed = false;
        Questmanager.doneLevel = false;
        Questmanager.fuelQuest = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        winGame();
        loseGame();
    }

    public void winGame()
    {
        if (Questmanager.doneLevel == true)
        {
            winCanv.SetActive(true);
        }
    }

    public void loseGame()
    {
        if(Npc.veryPissed == true)
        {
           loseCanv.SetActive(true);
        }
        if (Player.detection >= 100)
        {
            loseCanv.SetActive(true);
        }

    }

    public void restartGame()
    {
        SceneManager.LoadScene("Project vlucht");

    }

    public void easterEggscene()
    {
        SceneManager.LoadScene("sim");
    }
}
