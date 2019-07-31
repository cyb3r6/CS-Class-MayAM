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
        
    }
}
