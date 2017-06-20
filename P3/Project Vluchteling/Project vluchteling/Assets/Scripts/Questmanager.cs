using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Questmanager : MonoBehaviour {
    public static bool fuelQuest;
    public static bool completed;
    public Text questText;
    public static bool doneLevel;
	// Use this for initialization
	void Start () {
        questText.text = "No quest";

    }
	
	// Update is called once per frame
	void Update () {
        FuelQeust();
    }

    public void FuelQeust()
    {
        if(fuelQuest == true)
        {
            questText.text = "Find the fuel in the park";
            if(Gamemanager.hasPickup == true)
            {
                completed = true;
                questText.text = "Return to Frank";
            }
        }
    }
}
