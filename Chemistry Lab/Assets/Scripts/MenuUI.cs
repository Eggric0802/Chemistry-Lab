using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour {

    public GameObject menuObj;
    public bool isOn;
    
    void FixedUpdate()
    {
        if (isOn == false)
        {
            menuObj.SetActive(false);
        }
        else if (isOn == true)
        {
            menuObj.SetActive(true);
        }

    }
}
