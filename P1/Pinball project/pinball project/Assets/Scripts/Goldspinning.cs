using UnityEngine;
using System.Collections;

public class Goldspinning : MonoBehaviour {
    
    public GameObject gold;
    public Vector3 teleportback;
    public GameObject gate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * 1); //Laat de goudstaaf ronddraaien
        
	}
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bal(Clone)") //On collision met de bal
        {
            Score.points = Score.points * 4; //Doet de huidige score *4
            Destroy(gold); // Vernietigd de goudstaaf
            col.gameObject.transform.position =  (teleportback); //Teleport de bal terug de baan in
            gate.transform.position = new Vector3(-1.407F, 0.53F, -11.135F); // Zet de gate voor de ingang zodat de bal er niet meer in kan
            gate.transform.Rotate(90, transform.rotation.y, transform.rotation.z); // Zet de gate rechtop

        }
    }

}
