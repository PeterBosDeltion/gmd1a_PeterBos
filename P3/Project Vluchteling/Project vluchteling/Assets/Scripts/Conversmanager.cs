using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversmanager : MonoBehaviour {
    public static bool inConv;
    public InputField talkConv;
    public List<string> insults = new List<string>();
    public string insultConv;
    public static string npcConv;
    public Text npcScrnTxt;
    public static int posInt;
    public static int negInt;
    public static Npc npc;
    


    // Use this for initialization
    void Start () {
        talkConv.onEndEdit.AddListener(delegate { Talking(talkConv); });
        negInt = 0;
        posInt = 0;
        
       
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void Talking(InputField input)
    {

        if (input.text == "A" || input.text == "a")
        {
            postCont();
        }
        else if (input.text == "B" || input.text == "b")
        {
            negtCont();
        }
        else
        {
            calcInsult();
        }
    }

    public void calcInsult()
    {
        int i = Random.Range(0, insults.Count);
        npcConv = insults[i];
        gameObject.GetComponent<Uimanager>().setText();

    }

    public void clearTxt()
    {
        npcConv = "";
        npcScrnTxt.text = "";
    }

    public void postCont()
    {
        posInt += 1;
        npc.talkPos();
       
        
    }

    public void negtCont()
    {
        negInt += 1;
        posInt = 0;
        npc.talkNeg();
    }

    public void clearCont()
    {
        negInt = 0;
        posInt = 0;
    }

    public void sendTxt()
    {
        gameObject.GetComponent<Uimanager>().setText();
    }
}
