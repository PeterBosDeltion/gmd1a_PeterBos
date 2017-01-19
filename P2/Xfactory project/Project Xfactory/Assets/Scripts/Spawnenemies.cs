using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemies : MonoBehaviour {
    public GameObject[] enemy;
    public int amount;
    public Vector3 spawnpoint;
    public int allowedamount;
    public Vector3 corner1;
    public Vector3 corner2;
    public Vector3 corner3;
    public Vector3 corner4;
    public Vector3 spawnheight;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        amount = enemy.Length;
      if(amount != allowedamount)
        {
            InvokeRepeating("spawning", 1, 15.0F);
        }

      if(amount >= allowedamount)
        {
            CancelInvoke();
        }
    }

    public void spawning()
    {
        spawnpoint.x = Random.Range(corner1.x, corner2.x);
        spawnpoint.y = spawnheight.y;
        spawnpoint.z = Random.Range(corner3.z, corner4.z);

        Instantiate(enemy[UnityEngine.Random.Range(0, enemy.Length - 1)], spawnpoint, Quaternion.identity);

        CancelInvoke();
    }
}
