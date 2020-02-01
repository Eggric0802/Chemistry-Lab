using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaFill : MonoBehaviour
{
    public GameObject objToDestroy;
    public GameObject objToSpawn1, objToSpawn2, objToSpawn3;

    public Animator anim;

    //public Renderer rend;
    // Use this for initialization
    void Start()
    {
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //objToDestroy.SetActive(false);
        //objToSpawn.SetActive(true);

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

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "LeadInsoluble")
        {
            Debug.Log("Collide Pb");
            objToDestroy.SetActive(false);
            objToSpawn1.SetActive(true);
        }
        if (col.gameObject.tag == "CopperSoluble")
        {
            Debug.Log("Collide Cu");
            objToDestroy.SetActive(false);
            objToSpawn2.SetActive(true);
        }
        
        if (col.gameObject.tag == "AmmeniaSoluble")
        {
            Debug.Log("Collide NH4");
            objToDestroy.SetActive(false);
            objToSpawn3.SetActive(true);
        }
    }

}
