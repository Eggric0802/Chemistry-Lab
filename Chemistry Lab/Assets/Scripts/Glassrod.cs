using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glassrod : MonoBehaviour
{
    public Animator anim;

    public Material[] material;
    Renderer rend;
    //GameObject gameObject = new GameObject;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        anim = GetComponent<Animator>();
        anim.enabled = false;
        //anim.StopPlayback();
        //StartCoroutine(StartAnim());
    }

    // Update is called once per frame
    void Update()
    {        

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
        rend.sharedMaterial = material[0];
        yield return new WaitForSeconds(1);
        //rend.sharedMaterial = material[0];
        Destroy(anim);
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "CopperSoluble")
        {
            rend.sharedMaterial = material[1];
            rend.tag = "CopperGR";
            //col.gameObject.tag = "CopperSulphate";
        }
        if (col.gameObject.tag == "LeadInsoluble")
        {
            rend.sharedMaterial = material[2];
            rend.tag = "LeadGR";
        }
        if (col.gameObject.tag == "AmmeniaSoluble")
        {
            rend.sharedMaterial = material[3];
            rend.tag = "AmmoniaGR";
        }

    }
}
