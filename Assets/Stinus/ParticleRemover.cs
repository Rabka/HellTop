using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRemover : MonoBehaviour
{

    public float RemovalDelay = 5;

	// Use this for initialization
	void Start () {
	    Destroy(gameObject, RemovalDelay);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
