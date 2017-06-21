using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gamemanager : MonoBehaviour {
    public UiManager uim;
    public Inventory inv;

    public List<GameObject> allItems = new List<GameObject>();

    public GameObject gObjOne;
    public GameObject gObjTwo;

    public GameObject addedObj;

    public List<GameObject> invButt = new List<GameObject>();
	// Use this for initialization
	void Start () {
        FindSlots();
        uim = GameObject.FindGameObjectWithTag("UIM").GetComponent<UiManager>();
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        //inv.inventory.Add(gObjOne);
        //inv.inventory.Add(gObjTwo);
        inv.CheckInv();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FindSlots()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");
        foreach (GameObject g in slots)
        {
            GameObject but = g;
            invButt.Add(but);
        }
    }

    public void AddRandomItem()
    {
        if(inv.inventory.Count < inv.invslots)
        {
            int i = Random.Range(0, allItems.Count);
            addedObj = allItems[i];
            inv.inventory.Add(allItems[i]);
            inv.CheckSlot();
        }
    }
}
