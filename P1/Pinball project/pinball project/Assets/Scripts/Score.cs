using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    public static float points = 0;
    public Text score;
    public Text endscore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        score.text = "Score:  " + points; //Zet de scoretext naar de huidige score
        endscore.text = "Score  " + points; //Zet de scoretext op het gameoverscherm naar de huidige score
	}
}


