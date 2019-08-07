using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravitationObject : MonoBehaviour
{
    public Rigidbody rigidBody;     // this objects rigidbody

    private Vector3 initialForce;   // initial force to apply orbiting behaviour
    public Vector3 endForce;        // force to apply in the update

    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        Gravity.gravityObjects.Add(this);
    }

    public void AddEndForce()
    {
        if(endForce != Vector3.zero)
        {
            rigidBody.AddForce(endForce);
            endForce = Vector3.zero;
        }
    }
    
}
