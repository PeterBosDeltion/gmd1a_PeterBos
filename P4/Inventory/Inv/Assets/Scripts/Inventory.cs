using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public List<GameObject> inventory = new List<GameObject>();
    public Gamemanager gm;

    public static GameObject panelStat;
    public int invslots = 27;


    public Sprite defaultSlotSprite;
	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemanager>();
        panelStat = GameObject.FindGameObjectWithTag("StatPan");
        panelStat.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            CheckInv();
        }
	}

    public void CheckInv()
    {
        foreach (GameObject g in inventory)
        {
            int i = inventory.IndexOf(g);
            if (gm.invButt[i].GetComponent<InvButton>().currentItem == null)
            {
                gm.invButt[i].GetComponent<InvButton>().currentItem = g.GetComponent<Item>();
                //gm.invButt[i].GetComponent<Button>().GetComponentInChildren<Text>().text = "" + g.GetComponent<Item>().itemName;
            }
            else if (gm.invButt[i].GetComponent<InvButton>().currentItem != null)
            {
                i += 1;
                gm.invButt[i].GetComponent<InvButton>().currentItem = g.GetComponent<Item>();
               //gm.invButt[i].GetComponent<Button>().GetComponentInChildren<Text>().text = "" + g.GetComponent<Item>().itemName;
                

            }

        }
    }

    public void CheckSlot()
    {
        if(inventory.Count < invslots)
        {
            int i = inventory.Count;
            GameObject g = gm.addedObj;
            if (gm.invButt[i].GetComponent<InvButton>().currentItem == null)
            {
                gm.invButt[i].GetComponent<InvButton>().currentItem = g.GetComponent<Item>();
                //gm.invButt[i].GetComponent<Button>().GetComponentInChildren<Text>().text = "" + g.GetComponent<Item>().itemName;
            }
            else if (gm.invButt[i].GetComponent<InvButton>().currentItem != null)
            {
                i += 1;
                gm.invButt[i].GetComponent<InvButton>().currentItem = g.GetComponent<Item>();
                //gm.invButt[i].GetComponent<Button>().GetComponentInChildren<Text>().text = "" + g.GetComponent<Item>().itemName;


            }
        }
    }
}
