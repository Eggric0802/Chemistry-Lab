using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBeam : MonoBehaviour
{
    public bool isOn;
    public GameObject beamObj;
    SteamVR_LaserPointer laserpointer;
    //public GameObject beam;

    void FixedUpdate()
    {
        if (isOn == false)
        {
            laserpointer = beamObj.GetComponent<SteamVR_LaserPointer>();
            laserpointer.active = false;
            //beam = laserpointer.pointer;
            //beam.SetActive(false);
            
            //   isOn = false;
        }

        if (isOn == true)
        {
            laserpointer = beamObj.GetComponent<SteamVR_LaserPointer>();
            laserpointer.active = true;
            //beam = laserpointer.pointer;
            //beam.SetActive(true);
            
            //    isOn = true;
        }

    }
}
