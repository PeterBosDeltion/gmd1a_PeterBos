using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {
    public List<int> enemies = new List<int>();
    public GameObject enemy;
    public GameObject secretspawn;
    public bool pinguspawned;
	// Use this for initialization
	void Start () {
        Score.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        updatescore();
        secretenemy();
	}

    public void updatescore()
    {
        gameObject.GetComponent<Score>().checkScore();
    }

    public void secretenemy()
    {
        if(Summonsecretenemy.done == true)
        {
            enemies[1] = 1;
            
            

        }

        if(enemies[1] == 1)
        {
            if (pinguspawned == false)
            {
                Instantiate(enemy, secretspawn.transform.position, secretspawn.transform.rotation);
                pinguspawned = true;
            }
        }
    }
}
