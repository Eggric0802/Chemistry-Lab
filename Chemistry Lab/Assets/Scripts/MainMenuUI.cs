using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

    public GameObject menuObj;
    public bool isOn;

    void FixedUpdate()
    {
        if (isOn == true && menuObj.active == true)
        {
            SteamVR_LaserPointer laserPointer = GetComponent<SteamVR_LaserPointer>();
            SteamVR_TrackedController trackedController = GetComponent<SteamVR_TrackedController>();

            laserPointer.enabled = false;
            trackedController.enabled = false;

            isOn = false;
        }
    }
}
