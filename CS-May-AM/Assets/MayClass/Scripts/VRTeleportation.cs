using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleportation : MonoBehaviour
{
    public bool isleftHand;
    public Transform vrRig;
    private string trackPad;
    private float grip;
    private LineRenderer laser;


    private void Awake()
    {
        laser = GetComponent<LineRenderer>();

        if (isleftHand)
        {
            trackPad = "LeftTrackPadPress";
        }
        else
        {
            trackPad = "RightTrackPadPress";
        }
        // Ternary Operator
        //trackPad = isleftHand ? "LeftTrackPadPress" : "RightTrackPadPress";

    }

    
    void Update()
    {
        if (Input.GetButton(trackPad))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                // do something
            }
        }
    }
}
