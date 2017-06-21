using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour {
    public GameObject player;
    public Inventory playInv;

    public GameObject invUi;
    private bool inInv = true;

    public GameObject buttPref;
    public GameObject invCont;
    public GameObject invCanv;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playInv = player.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!inInv)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                invUi.SetActive(true);
                playInv.CheckInv();
                //OpenInv();
                inInv = true;
            }

        }
        else if (inInv)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                invUi.SetActive(false);
                inInv = false;
            }
        }
	}

    //public void OpenInv()
    //{
    //    foreach (GameObject g in playInv.inventory)
    //    {
    //       GameObject button = Instantiate(buttPref, transform.position, Quaternion.identity);
    //       button.GetComponentInChildren<Text>().text = "HOI";
    //       button.transform.SetParent(invCont.transform);
    //    }
    //}
}
