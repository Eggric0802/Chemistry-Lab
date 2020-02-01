using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrain : MonoBehaviour
{
    AudioSource audioData;
    public AudioClip AudioAmmonia;
    public AudioClip AudioCopper;
    public AudioClip AudioLead;

    public Material[] material;
    Renderer rend;
    public GameObject FireAmmonia, FireCopper, FireLead;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //rend.sharedMaterial = material[0];
        audioData = GetComponent<AudioSource>();
        audioData.clip = AudioCopper;

        FireAmmonia.SetActive(false);
        FireCopper.SetActive(false);
        FireLead.SetActive(false);

    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "CopperGR")
        {
            //System.Threading.Thread.Sleep(2000);
            //rend.sharedMaterial = material[2];
            FireCopper.SetActive(true);
            StartCoroutine(ActivationRoutine(FireCopper));
            audioData.clip = AudioCopper;
            audioData.Play();
            
        }

        if (col.gameObject.tag == "LeadGR")
        {
            //System.Threading.Thread.Sleep(2000);
            //rend.sharedMaterial = material[2];
            FireLead.SetActive(true);
            StartCoroutine(ActivationRoutine(FireLead));
            audioData.clip = AudioLead;
            audioData.Play();
            
        }

        if (col.gameObject.tag == "AmmoniaGR")
        {
            //System.Threading.Thread.Sleep(2000);
            //rend.sharedMaterial = material[2];
            FireAmmonia.SetActive(true);
            StartCoroutine(ActivationRoutine(FireAmmonia));
            audioData.clip = AudioAmmonia;
            audioData.Play();
            
        }

    }
    private IEnumerator ActivationRoutine(GameObject text)
    {
        //Wait for 14 secs.
        yield return new WaitForSeconds(8);
        text.SetActive(false);


    }
}

