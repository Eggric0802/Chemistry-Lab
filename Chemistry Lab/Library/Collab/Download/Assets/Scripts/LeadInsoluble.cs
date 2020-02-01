using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class LeadInsoluble : MonoBehaviour
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
			col.gameObject.tag = "LeadWater";
            //Thread.Sleep(2000);
            //rend.enabled = false;
            //rend.sharedMaterial = material[1];
            //if (rend.sharedMaterial = material[1])
            //{
            //System.Threading.Thread.Sleep(2000);
            //rend.enabled = false;
            //}
        }

    }


}


