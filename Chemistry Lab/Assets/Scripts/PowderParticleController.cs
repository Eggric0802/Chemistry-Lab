using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderParticleController : MonoBehaviour {
	public ParticleSystem particles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > .5f) {
            particles.Pause();
           }
	}
}
