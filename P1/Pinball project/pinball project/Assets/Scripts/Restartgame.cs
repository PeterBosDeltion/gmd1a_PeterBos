using UnityEngine;
using System.Collections;

public class Restartgame : MonoBehaviour {
    public GameObject menu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnClick()
    {
        menu.SetActive(false); //Zet het gameoverscreen inactief

    }
}
