using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AmmeniaSoluble : MonoBehaviour
{



    public Material[] material;
    Renderer rend;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
	
        //rend.sharedMaterial = material[0];
    }



    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "water1")
        {
		col.gameObject.tag = "AmmoniaWater";
            //Thread.Sleep(2000);
            //rend.enabled = false;
            //gameObject.active = false;
            gameObject.SetActive(false);
        }

    }


}
