using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public static float detection;
    public Text detText;
    public GameObject map;
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        detectionBar();
        buttons();
        

    }

    public void detectionBar()
    {
        if (detection <= 100)
        {
            detText.text = "" + detection + "%";
        }
    }

    public void buttons()
    {
        if(Gamemanager.hasMap == true)
        { 
        if (Input.GetButtonDown("m"))
        {
                map.SetActive(true);
        }
            if (Input.GetButtonDown("Cancel"))
            {
                map.SetActive(false);
            }
        }
    }
}
