using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaFill : MonoBehaviour {
	public GameObject objToDestroy;
	public GameObject objToSpawn1,objToSpawn2,objToSpawn3;
	
	//public Renderer rend;
	// Use this for initialization
	void Start () {
		//rend = GetComponent<Renderer>();
        //rend.enabled = true;
		//objToDestroy.SetActive(false);
		//objToSpawn.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
			}
	private void OnCollisionEnter(Collider col)
	{
		if (col.gameObject.tag == "PowderCopper")
		{
			Debug.Log("Collide Cu");
			objToDestroy.SetActive(false);
			objToSpawn1.SetActive(true);
		}
		if (col.gameObject.tag == "PowderLead")
        {
        	Debug.Log("Collide Pb");
        	objToDestroy.SetActive(false);
			objToSpawn2.SetActive(true);
		}	
        	if (col.gameObject.tag == "PowderAmmonia")
        {
        	Debug.Log("Collide NH4");
        	objToDestroy.SetActive(false);
			objToSpawn3.SetActive(true);
		}	
	}
				
}
