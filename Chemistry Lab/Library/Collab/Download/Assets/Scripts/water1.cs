using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water1 : MonoBehaviour
{
    AudioSource audioData;
    public AudioClip AudioAmmonia;
    public AudioClip AudioCopper;
    public AudioClip AudioLead;

    public Material[] material;
    Renderer rend;
    public GameObject TextAmmonia, TextCopper, TextLead;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        audioData = GetComponent<AudioSource>();

        TextAmmonia.SetActive(false);
        TextCopper.SetActive(false);
        TextLead.SetActive(false);

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "CopperSoluble")
        {
            //System.Threading.Thread.Sleep(2000);
            rend.sharedMaterial = material[2];
		col.gameObject.tag = "CopperUsed";
            TextCopper.SetActive(true);
            audioData.clip = AudioCopper;
            audioData.Play();
            StartCoroutine(ActivationRoutine(TextCopper));
        }

        if (col.gameObject.tag == "LeadInsoluble")
        {
            //System.Threading.Thread.Sleep(2000);
            //rend.sharedMaterial = material[2];
		col.gameObject.tag = "LeadUsed";

            TextLead.SetActive(true);
            audioData.clip = AudioLead;
            audioData.Play();
            StartCoroutine(ActivationRoutine(TextLead));
        }

        if (col.gameObject.tag == "AmmeniaSoluble")
        {
            //System.Threading.Thread.Sleep(2000);
            //rend.sharedMaterial = material[2];
		col.gameObject.tag = "AmmoniaUsed";

            TextAmmonia.SetActive(true);
            audioData.clip = AudioAmmonia;
            audioData.Play();
            StartCoroutine(ActivationRoutine(TextAmmonia));
        }

    }
    private IEnumerator ActivationRoutine(GameObject text)
    {
        //Wait for 14 secs.
        yield return new WaitForSeconds(8);
        text.SetActive(false);
		


    }
}

