using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSeed : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<ParticleSystem>().Stop();
        this.GetComponent<ParticleSystem>().randomSeed = 1999999;
        this.GetComponent<ParticleSystem>().Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
