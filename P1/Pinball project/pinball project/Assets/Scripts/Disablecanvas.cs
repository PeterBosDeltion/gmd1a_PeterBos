using UnityEngine;
using System.Collections;

public class Disablecanvas : MonoBehaviour {
    public GameObject menu;
	// Use this for initialization
	void Start () {
        menu.SetActive(false); //Zet het menu op inactief als de scene start
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
