using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerhp : MonoBehaviour {
    public static float health = 100;
    public Text hptext;
    public GameObject gameoverUI;
    
	// Use this for initialization
	void Start () {
        gameoverUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        hptext.text = "" + health;
        ded();
        if (Input.GetKeyDown("f"))
        {
            health = 0;
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bullet(Clone)")
        {
            health = health - 10;
        }
    }

    public void ded()
    {
        if(health <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            hptext.text = "Dead";
            gameoverUI.SetActive(true);
            Destroy(gameObject);
           
        }
    }
}
