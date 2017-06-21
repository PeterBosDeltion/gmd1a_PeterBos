using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mouse : MonoBehaviour {
    public static Item draggedItem;

    public static Sprite draggedSprite;
    public static Image dragImg;
    public static GameObject dragImgObj;
	// Use this for initialization
	void Start () {

        dragImg = GetComponentInChildren<Image>();
        dragImgObj = GameObject.FindGameObjectWithTag("DRIO");

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
	}
}
