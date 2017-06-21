using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvButton : MonoBehaviour {
    public Inventory inv;
    public Item currentItem;
    public GameObject mouseOverPan;

    public static bool isStatPanel;
    public GameObject temp2;

    public UiManager uim;
    public bool checkedforUi;

    public Image img;
    public bool checkSprite;

    public bool checkInv;

    public GameObject dragStartObject;
    public GameObject dragDummy;
    public Item tempItem;
    public GameObject draggedObject;
    public bool dragged;
    public static GameObject draggedOver;


    public bool hasItem;
    // Use this for initialization
    void Start () {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        img = GetComponent<Image>();

        //Need to find somewhere to load image other than start

        //if(currentItem != null)
        //{
        //    img.sprite = currentItem.itemSprite;
        //}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnGUI()
    {
        if (!checkedforUi)
        {
            uim = GameObject.FindGameObjectWithTag("UIM").GetComponent<UiManager>();
            checkedforUi = true;
        }

        if (!checkSprite)
        {
            if (currentItem != null)
            {
                img.sprite = currentItem.itemSprite;
                checkSprite = true;
            }
        }

        //if (!checkInv)
        //{
        //    inv.CheckInv();
        //}
    }

    public void StatsMenu()
    {
        if (!isStatPanel)
        {
            //GameObject temp = Instantiate(mouseOverPan, Input.mousePosition, Quaternion.identity);
            if(currentItem != null)
            {

                Vector3 mos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                Inventory.panelStat.transform.position = mos;
                Inventory.panelStat.SetActive(true);

                Inventory.panelStat.GetComponentInChildren<Text>().text = "Name: " + currentItem.itemName + "\n" + "Price: " + currentItem.price + "\n" + "Weight: " + currentItem.weight;

                isStatPanel = true;
            }
            //temp.transform.SetParent(uim.invCanv.gameObject.transform);
            //temp2 = temp;
        }
    }

    public void Clear()
    {
        StartCoroutine(ClearStats());
    }

    public IEnumerator ClearStats()
    {
        yield return new WaitForSeconds(0.2F);
        if (isStatPanel)
        {
            Inventory.panelStat.SetActive(false);
            isStatPanel = false;
        }
    }

    public void Drag()
    {
        if(currentItem != null)
        {
            draggedObject.transform.position = Input.mousePosition;
        }
        //Item temp = currentItem;
        //Mouse.draggedItem = temp;
        //Mouse.draggedSprite = temp.itemSprite;
        //Mouse.dragImg.sprite = Mouse.draggedSprite;
        //Mouse.dragImgObj.SetActive(true);
    }

    public void StartDrag()
    {
        dragStartObject = gameObject;
        tempItem = currentItem;
        Sprite sprit = currentItem.itemSprite;
        draggedObject = Instantiate(dragDummy, Input.mousePosition, Quaternion.identity);
        draggedObject.transform.SetParent(uim.invCanv.transform);
        draggedObject.GetComponent<Image>().sprite = sprit;
    }

    public void EndDrag()
    {
        if (!draggedOver.GetComponent<InvButton>().hasItem)
        {
            draggedOver.GetComponent<InvButton>().currentItem = tempItem;
            draggedOver.GetComponent<InvButton>().GetComponent<Image>().sprite = draggedObject.GetComponent<Image>().sprite;
            draggedOver.GetComponent<InvButton>().hasItem = true;
            currentItem = null;
            hasItem = false;
            GetComponent<Image>().sprite = inv.defaultSlotSprite;
            Destroy(draggedObject);
        }
        else if (draggedOver.GetComponent<InvButton>().hasItem)
        {
            Swap();
        }
    }

    public void CheckItem()
    {
        if(currentItem == null)
        {
            hasItem = false;
        }
        else if(currentItem != null)
        {
            hasItem = true;
        }
    }

    public void FillObject()
    {
            draggedOver = gameObject;

    }

    public void Swap()
    {
        //all info of object on end drag needs to go to dragStartObject
        currentItem = draggedOver.GetComponent<InvButton>().currentItem;
        GetComponent<Image>().sprite = draggedOver.GetComponent<InvButton>().GetComponent<Image>().sprite;
        //draggedOver.GetComponent<InvButton>().hasItem = true;
        //currentItem = draggedOver.GetComponent<Item>();
        hasItem = true;
        //GetComponent<Image>().sprite = inv.defaultSlotSprite;

        draggedOver.GetComponent<InvButton>().currentItem = tempItem;
        draggedOver.GetComponent<InvButton>().GetComponent<Image>().sprite = draggedObject.GetComponent<Image>().sprite;
        draggedOver.GetComponent<InvButton>().hasItem = true;
        //currentItem = null;
        //hasItem = false;
        //GetComponent<Image>().sprite = inv.defaultSlotSprite;

        Destroy(draggedObject);

    }
}
