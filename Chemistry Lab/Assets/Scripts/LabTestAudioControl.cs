using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabTestAudioControl : MonoBehaviour
{

    // Use this for initialization
    AudioSource audioSource;
    public AudioClip[] audio;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audio[0];
        audioSource.Play();
        StartCoroutine(ActivationRoutine());
    }

    // Update is called once per frame

    private IEnumerator ActivationRoutine()
    {
        //Wait for 14 secs.

        yield return new WaitForSeconds(4);
        audioSource.clip = audio[1];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[2];
        audioSource.Play();


    }
}
