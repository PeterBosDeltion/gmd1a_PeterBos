using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {
    public static float HP = 6;
    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public GameObject bar4;
    public GameObject bar5;
    public GameObject bar6;
    public GameObject Fire;
    public static bool onfire = false;
    public static bool winner = false;
    // Use this for initialization
    void Start () {
        Fire.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if(HP <= 5) //Per HP dat mist word er een stukje van de healthbar gedestroyed
        {
            Destroy(bar1);
        }
        if (HP <= 4)
        {
            Destroy(bar2);
        }
        if (HP <= 3)
        {
            Destroy(bar3);
        }
        if (HP <= 2)
        {
            Destroy(bar4);
        }
        if (HP <= 1)
        {
            Destroy(bar5);
        }
        if (HP <= 0)
        {
            Destroy(bar6);
        }
        if (HP <= 0)
        {
            Fire.SetActive(true); //Activeerd de particleemitter voor vuur
            onfire = true; //Zet actief dat je geen extra levens meer krijgt als je het kasteel raakt
            winner = true; //Zet de winnertext actief als al de levens op zijn
        }
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bal(Clone)")
        {
            HP = HP - 1; //Als de bal het kasteel raakt gaat er 1 HP van het kasteel af
            GetComponent<AudioSource>().Play(); //Speelt een geluidje (er is geen reden voor dit specefieke geluid anders dan waarom niet)
        }
    }
}
