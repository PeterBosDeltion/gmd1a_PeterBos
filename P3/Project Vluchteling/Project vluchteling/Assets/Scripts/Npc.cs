using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Npc : MonoBehaviour {
    public List<string> speechpos = new List<string>();
    public List<string> speechneg = new List<string>();
    public GameObject gm;
    public static string talk;
    public Conversmanager convman;
    public static bool veryPissed;

	// Use this for initialization
	void Start ()
    {
        talk = "";
    }
	
	// Update is called once per frame
	void Update () {
        GiveMap();
        WarnGuards();
        GiveQuest();
        PrettyAngry();

    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetButtonDown("e"))
            {
                Conversmanager.inConv = true;
                Conversmanager.npc = this;
                StartTxt();
            }
            if(gameObject.name == "Frank")
            {
                if(Questmanager.completed == true)
                {
                    if (Input.GetButtonDown("e"))
                    {
                        Questmanager.doneLevel = true;
                    }
                }
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Conversmanager.inConv = false;
            gm.GetComponent<Conversmanager>().ClearTxt();
            convman.ClearCont();
            

        }

    }

    public void TalkPos()
    {
        talk = speechpos[Conversmanager.posInt];
        Conversmanager.npcConv = talk;
        convman.SendTxt();
    }

    public void TalkNeg()
    {
        talk = speechneg[Conversmanager.negInt];
        Conversmanager.npcConv = talk;
        convman.SendTxt();
    }

    public void StartTxt()
    {
        talk = speechpos[0];
        Conversmanager.npcConv = talk;
        convman.SendTxt();
    }

    public void GiveMap()
    {
        if(gameObject.name == "Hanz")
        {
            if(talk == speechpos[4])
            {
                Gamemanager.hasMap = true;
            }
        }
    }

    public void WarnGuards()
    {
        if (gameObject.name == "Hanz")
        {
            if (talk == speechneg[2])
            {
                Enemy.isHard = true;
            }
        }
    }

    public void GiveQuest()
    {
        if(gameObject.name == "Frank")
        {
            if(talk == speechpos[5])
            {
                Questmanager.fuelQuest = true;
                Debug.Log(Questmanager.fuelQuest);
            }
           
        }
    }

    public void PrettyAngry()
    {
        if(gameObject.name == "Frank")
        {
            if(talk == speechneg[5])
            {
                veryPissed = true;
            }
        }
    }
   
}
