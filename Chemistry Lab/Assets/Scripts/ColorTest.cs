using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour
{

    // Use this for initialization

    //public AudioSource intro, safetygoggles1, safetygoggles2, safetygoggles3, safetygoggles4;
    AudioSource audioSource;
    public AudioClip[] audio;
    public GameObject salt1, salt2, salt3;//salt3;
    public GameObject label1, label2, label3;
    public GameObject color1, color2, color3;
    public Material glass, shader;

    public Glassrod gs;
    public Goggles g;
    public SpatulaFill emptySpoon;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audio[0];
        audioSource.Play();
        label1.SetActive(false);
        label2.SetActive(false);
        label3.SetActive(false);
        color1.SetActive(false);
        color2.SetActive(false);
        color3.SetActive(false);
        StartCoroutine(ActivationRoutine());
    }

    // Update is called once per frame

    private IEnumerator ActivationRoutine()
    {
        //Wait for 14 secs.

        yield return new WaitForSeconds(4);
        audioSource.clip = audio[1];
        audioSource.Play();
        StartCoroutine(g.StartAnim());
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[2];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[3];
        audioSource.Play();
        yield return new WaitForSeconds(6);
        audioSource.clip = audio[4];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[5];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[6];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[7];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[8];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[9];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[10];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[11];
        audioSource.Play();
        yield return new WaitForSeconds(7);
        audioSource.clip = audio[12];
        audioSource.Play();
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[13];
        audioSource.Play();
        yield return new WaitForSeconds(4);
        audioSource.clip = audio[14];
        audioSource.Play();
        yield return new WaitForSeconds(4);
        //colorless
        audioSource.clip = audio[15];
        audioSource.Play();
        label1.SetActive(true);
        label3.SetActive(true);
        color1.SetActive(true);
        color3.SetActive(true);
        salt3.GetComponent<Renderer>().material = shader;
        salt1.GetComponent<Renderer>().material = shader;

        yield return new WaitForSeconds(5);
        //blue
        audioSource.clip = audio[16];
        audioSource.Play();
        salt2.GetComponent<Renderer>().material = shader;
        salt1.GetComponent<Renderer>().material = glass;
        salt3.GetComponent<Renderer>().material = glass;
        label1.SetActive(false);
        label3.SetActive(false);
        label2.SetActive(true);
        color1.SetActive(false);
        color3.SetActive(false);
        color2.SetActive(true);
        yield return new WaitForSeconds(4);
        salt2.GetComponent<Renderer>().material = glass;
        color2.SetActive(false);
        label1.SetActive(true);
        label3.SetActive(true);
        yield return new WaitForSeconds(4);
        //solubility
        audioSource.clip = audio[17];
        audioSource.Play();

        StartCoroutine(emptySpoon.StartAnim());


        salt2.GetComponent<Renderer>().material = glass;
        color2.SetActive(false);
        label1.SetActive(true);
        label3.SetActive(true);
        yield return new WaitForSeconds(5);
        audioSource.clip = audio[18];
        audioSource.Play();
        yield return new WaitForSeconds(4);
        audioSource.clip = audio[19];
        audioSource.Play();
        yield return new WaitForSeconds(4);
        audioSource.clip = audio[20];
        audioSource.Play();
        yield return new WaitForSeconds(4);
        audioSource.clip = audio[21];
        audioSource.Play();
        yield return new WaitForSeconds(4);
        audioSource.clip = audio[22];
        audioSource.Play();
        //Glassrod gs = new Glassrod();
        //gs.anim = enabled
        StartCoroutine(gs.StartAnim());





        //yield return new WaitForSeconds(5);



        yield return new WaitForSeconds(4);

    }
}
