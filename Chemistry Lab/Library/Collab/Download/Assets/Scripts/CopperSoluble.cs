using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopperSoluble : MonoBehaviour
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
            gameObject.SetActive(false);
		col.gameObject.tag = "CopperWater";



        }

    }


}
