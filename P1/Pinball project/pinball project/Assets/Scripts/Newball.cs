using UnityEngine;
using System.Collections;

public class Newball : MonoBehaviour
{
    public GameObject Plane;
    public GameObject Balrespawner;
    public GameObject Bal;
    public bool extralife;
    public GameObject menu;
    public GameObject wintext;
    public GameObject losetext;
    
    // Use this for initialization
    void Start()
    {
        Instantiate(Bal, Balrespawner.transform.position, Balrespawner.transform.rotation); //Geeft een bal als de scene start
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Castle.winner == true) //Als het kasteel in de brand staat
        {
            wintext.SetActive(true); //Zet de wintext actief op het gameoverscherm
            losetext.SetActive(false); //Zet de losetext inactief op het gameoverscherm
        }
       if(Ballscript.HP < 0)
        {
            menu.SetActive(true); //Als er geen levens meer zijn zet het gameoverscherm actief
        }
       
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bal") //Als de bal het plane onder de flipperkast raakt
        {
            Destroy(col.gameObject); //Vernietigd de bal
            if (Ballscript.HP >0) //Als er nog levens beschikbaar zijn
            {
                
                Instantiate(Bal, Balrespawner.transform.position, Balrespawner.transform.rotation); //Plaats een nieuwe bal
                
            }
        }
        if (col.gameObject.name == "Bal(Clone)") //Zie commentaar hierboven
        {
            Destroy(col.gameObject);
            if (Ballscript.HP > 0)
            {
                
                Instantiate(Bal, Balrespawner.transform.position, Balrespawner.transform.rotation);
                
            }
            
        }
    }
}
