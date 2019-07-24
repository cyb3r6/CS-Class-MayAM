using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleportation : MonoBehaviour
{
    public bool isleftHand;
    public Transform vrRig;
    private string trackPad;
    private LineRenderer laser;
    private Vector3 hitPoint;
    private bool shouldTeleport;


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
                hitPoint = hit.point;
                laser.SetPosition(0, transform.position);
                laser.SetPosition(1, hitPoint);
                laser.enabled = true;
                shouldTeleport = true;
            }
        }

        if (Input.GetButtonUp(trackPad))
        {
            // do the thing -> teleport
            if(shouldTeleport == true)
            {
                vrRig.transform.position = hitPoint;
                shouldTeleport = false;
                laser.enabled = false;
            }            
        }
    }
}
