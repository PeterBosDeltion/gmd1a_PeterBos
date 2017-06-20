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
            PostCont();
        }
        else if (input.text == "B" || input.text == "b")
        {
            negtCont();
        }
        else if(input.text == "Dyslexia" || input.text == "dyslexia")
        {
            GetComponent<Gamemanager>().EasterEggscene();
        }
        else
        {
            CalcInsult();
        }
    }

    public void CalcInsult()
    {
        int i = Random.Range(0, insults.Count);
        npcConv = insults[i];
        gameObject.GetComponent<Uimanager>().SetText();

    }

    public void ClearTxt()
    {
        npcConv = "";
        npcScrnTxt.text = "";
    }

    public void PostCont()
    {
        posInt += 1;
        npc.TalkPos();
       
        
    }

    public void negtCont()
    {
        negInt += 1;
        posInt = 0;
        npc.TalkNeg();
    }

    public void ClearCont()
    {
        negInt = 0;
        posInt = 0;
    }

    public void SendTxt()
    {
        gameObject.GetComponent<Uimanager>().SetText();
    }
}
