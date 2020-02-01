using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{

    public GameObject vision;
    public GameObject goggle;
    public bool isOn;


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "goggle")
        {
            isOn = true;
        }
    }


    void FixedUpdate()
    {
        if (isOn == true)
        {
            //goggle.active = false;
            //vision.active = true;
            vision.SetActive(true);
            goggle.SetActive(false);

        }
        else
        {
            //goggle.active = true;
            //vision.active = false;
            vision.SetActive(false);
            goggle.SetActive(true);
        }
    }
}
