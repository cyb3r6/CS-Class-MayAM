using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayableItem : MonoBehaviour
{
    //New script and added to any object to be obscured by invisible mask
    void Start()
    {
        //making sure the object has a renderer
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.renderQueue = 3002; //set renderQueue to render after our Invisible mask(3001)
        }
    }
}
