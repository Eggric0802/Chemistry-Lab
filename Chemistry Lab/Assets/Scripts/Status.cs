using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public ParticleSystem system;
    public AudioSource audio;
    public bool isOn;


    void FixedUpdate()
    {

        if (isOn == true)
        {
            system.Play();
            audio.mute = false;
        }
        else if (isOn == false)
        {
            system.Stop();
            audio.mute = true;
        }
    }
}