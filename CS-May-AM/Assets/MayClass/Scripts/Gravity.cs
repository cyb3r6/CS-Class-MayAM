using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public static List<GravitationObject> gravityObjects = new List<GravitationObject>();

    // force of gravity
    [Range(-10, 20)]
    public float gravitationalForce = 1f;
        

    
    void FixedUpdate()
    {
        int loopCount = 1;

        foreach(GravitationObject objectGravity in gravityObjects)
        {
            for(int i = loopCount; i< gravityObjects.Count; i++)
            {
                Rigidbody objectGravityRigidbody = objectGravity.rigidBody;
                CalculateGravity(objectGravity, gravityObjects[i], objectGravityRigidbody, gravityObjects[i].rigidBody);
            }
            loopCount++;
        }
        AddGravitationalForce();

    }


    void CalculateGravity(GravitationObject Object1, GravitationObject Object2, Rigidbody m1, Rigidbody m2)
    {
        Vector3 r = m1.position - m2.position;
        if(r == Vector3.zero)
        {
            return;
        }
        Vector3 force = r.normalized * (gravitationalForce * m1.mass * m2.mass / Mathf.Pow(r.magnitude, 2));

        Object1.endForce -= force;
        Object2.endForce += force;
    }
    void AddGravitationalForce()
    {
        foreach(GravitationObject tempObject in gravityObjects)
        {
            tempObject.AddEndForce();
        }
    }
}
