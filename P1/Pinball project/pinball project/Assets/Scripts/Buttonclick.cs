using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttonclick : MonoBehaviour {
    public GameObject gameoverscreen;
    public Button button;
    public GameObject menu;
     
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void onClick() //Als de restart knop word ingedrukt
    {
        
        SceneManager.LoadScene("flipkast"); //Reload de scene
        Ballscript.HP = 5; //Reset de levens
        Score.points = 0; //Reset de score
        Castle.HP = 6; //Reset het kasteel

        
       
    }
}
