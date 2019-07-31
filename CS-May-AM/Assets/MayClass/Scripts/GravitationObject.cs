using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationObject : MonoBehaviour
{
    public Rigidbody rigidBody;

    private Vector3 initialForce;
    public Vector3 endForce;

    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        Gravity.gravityObjects.Add(this);
    }

    
}
