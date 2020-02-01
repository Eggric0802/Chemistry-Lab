using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goggles : MonoBehaviour
{
    Animator anim;

    public GameObject vision;
    public GameObject goggle;
    public bool isOn;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    public IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(1);
        //anim.StartPlayback();
        anim.enabled = true;
        yield return new WaitForSeconds(5);
        StartCoroutine(DestroyAnim());
    }

    IEnumerator DestroyAnim()
    {
        //rend.sharedMaterial = material[0];
        yield return new WaitForSeconds(1);
        //rend.sharedMaterial = material[0];
        Destroy(anim);
    }



    void FixedUpdate()
    {
        if (isOn == true && goggle.active == true)
        {
            //vision.active = true;
            //goggle.active = false;
            vision.SetActive(true);
            goggle.SetActive(false);
            isOn = false;
        }
    }


}
