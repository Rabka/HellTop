using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    public ParticleSystem Particle;
    public Transform ThisTransform;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 parPosition = (ThisTransform.position + collision.transform.position) / 2;
        //parPosition.z = -3;
        Quaternion parRotation = Quaternion.LookRotation(ThisTransform.position - collision.transform.position);
        Instantiate(Particle, parPosition, parRotation);
    }
}
