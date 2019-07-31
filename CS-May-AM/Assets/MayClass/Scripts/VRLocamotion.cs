using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocamotion : MonoBehaviour
{
    public bool isLeftHand;
    public Transform vrRig;
    public Transform director;      // can be the head or controller
    private Vector3 playerForward;
    private Vector3 playerRight;
    private string trackpadX;
    private string trackpadY;
    private Vector2 trackPad;
    
    
    void Start()
    {
        if (isLeftHand)
        {
            trackpadX = "LeftTrackPadX";    // 0.5f
            trackpadY = "LeftTrackPadY";    // 0.8f
        }
        else
        {
            trackpadX = "RightTrackPadX";
            trackpadY = "RightTrackPadY";
        }
    }

    
    void Update()
    {
        trackPad = new Vector2(Input.GetAxis(trackpadX), Input.GetAxis(trackpadY));

        if (trackPad.magnitude < 0.2f)
        {
            trackPad = Vector2.zero;
        }


        playerForward = director.forward;
        playerForward.y = 0f;
        playerForward.Normalize();

        playerRight = director.right;
        playerRight.y = 0;
        playerRight.Normalize();

        vrRig.Translate(playerForward * trackPad.y * Time.deltaTime);
        vrRig.Translate(playerRight * trackPad.x * Time.deltaTime);
    }
}
