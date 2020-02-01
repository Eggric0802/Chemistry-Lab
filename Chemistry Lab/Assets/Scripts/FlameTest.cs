using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTest : MonoBehaviour
{

    public Material[] material;
    public Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {


    }

    // private void OnTriggerEnter(Collider col)
    // {

    //     if (col.gameObject.tag == "CopperSoluble" || col.gameObject.tag == "CopperGR")
    //     {
    //         //transform.GetComponent<ParticleSystemRenderer>().material = material[1];
    //         //rend.sharedMaterial = material[1];
    //         foreach (ParticleSystemRenderer p in rend.gameObject.GetComponentsInChildren<ParticleSystemRenderer>())
    //         {
    //             p.material = material[1];//Shader.Find(p.material.shader.name);
    //         }
    //         rend.tag = "CopperSoluble";
    //     }
    //     if (col.gameObject.tag == "LeadInsoluble" || col.gameObject.tag == "LeadGR")
    //     {
    //         foreach (ParticleSystemRenderer p in rend.gameObject.GetComponentsInChildren<ParticleSystemRenderer>())
    //         {
    //             p.material = material[2];//Shader.Find(p.material.shader.name);
    //         }
    //         rend.tag = "LeadInsoluble";
    //     }

    //     if (col.gameObject.tag == "AmmeniaSoluble" || col.gameObject.tag == "AmmoniaGR")
    //     {
    //         /*foreach (ParticleSystemRenderer p in rend.gameObject.GetComponentsInChildren<ParticleSystemRenderer>())
    //         {
    //             p.material = material[3];//Shader.Find(p.material.shader.name);
    //         }*/
    //         rend.tag = "AmmeniaSoluble";
    //     }


    // }


    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "CopperSoluble" || col.gameObject.tag == "CopperGR")
        {
            //transform.GetComponent<ParticleSystemRenderer>().material = material[1];
            //rend.sharedMaterial = material[1];
            foreach (ParticleSystemRenderer p in rend.gameObject.GetComponentsInChildren<ParticleSystemRenderer>())
            {
                p.material = material[1];//Shader.Find(p.material.shader.name);
            }
            rend.tag = "CopperSoluble";
        }
        if (col.gameObject.tag == "LeadInsoluble" || col.gameObject.tag == "LeadGR")
        {
            foreach (ParticleSystemRenderer p in rend.gameObject.GetComponentsInChildren<ParticleSystemRenderer>())
            {
                p.material = material[2];//Shader.Find(p.material.shader.name);
            }
            rend.tag = "LeadInsoluble";
        }

        if (col.gameObject.tag == "AmmeniaSoluble" || col.gameObject.tag == "AmmoniaGR")
        {
            /*foreach (ParticleSystemRenderer p in rend.gameObject.GetComponentsInChildren<ParticleSystemRenderer>())
            {
                p.material = material[3];//Shader.Find(p.material.shader.name);
            }*/
            rend.tag = "AmmeniaSoluble";
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        foreach (ParticleSystemRenderer p in rend.gameObject.GetComponentsInChildren<ParticleSystemRenderer>())
        {
            p.material = material[0];//Shader.Find(p.material.shader.name);
        }
        rend.tag = "Fire";
    }

    // private void OnTriggerExit(Collider collision)
    // {
    //     foreach (ParticleSystemRenderer p in rend.gameObject.GetComponentsInChildren<ParticleSystemRenderer>())
    //     {
    //         p.material = material[0];//Shader.Find(p.material.shader.name);
    //     }
    //     rend.tag = "Fire";
    // }
}
