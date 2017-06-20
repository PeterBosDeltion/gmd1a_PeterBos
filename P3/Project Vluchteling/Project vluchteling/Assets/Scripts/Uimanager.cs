using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour {
    public Text convTxt;
    public GameObject panelConv;
    // Use this for initialization
    void Start () {
       panelConv.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        ActvUi();
        if (Input.GetButtonDown("Cancel"))
        {
            panelConv.SetActive(false);
        }
    }

    public void SetText()
    {
        convTxt.text = Conversmanager.npcConv;
    }

    public void ActvUi()
    {
        if (Conversmanager.inConv == true)
        {
            panelConv.SetActive(true);
        }
        else
        {
            panelConv.SetActive(false);
        }
    }





}
