using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beakertop : MonoBehaviour
{
    public GameObject objToDestroyPb, objToDestroyCu, objToDestroyNH4;
    public GameObject objToSpawnEmptySpoon, objCu, objPb, objNH4;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "LeadSpoon")
        {
            Debug.Log("Collide Pb");
            objToDestroyPb.SetActive(false);
            objToSpawnEmptySpoon.SetActive(true);
            objPb.SetActive(true);
        }
		if (col.gameObject.tag == "CopperSpoon")
        {
            Debug.Log("Collide Cu");
            objToDestroyCu.SetActive(false);
            objToSpawnEmptySpoon.SetActive(true);
            objCu.SetActive(true);
        }
        if (col.gameObject.tag == "AmmoniaSpoon")
        {
            Debug.Log("Collide NH4");
            objToDestroyNH4.SetActive(false);
            objToSpawnEmptySpoon.SetActive(true);
            objNH4.SetActive(true);
        }
    }
}
