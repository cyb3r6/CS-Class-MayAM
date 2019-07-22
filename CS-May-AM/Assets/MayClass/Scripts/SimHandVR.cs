using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandVR : MonoBehaviour
{
    public Animator handAnim;
    public bool isLeftHand;     // if isLeftHand is true, then the script is attached to the left hand.
    public float forceMultiplier;

    private string trigger;        // to hold information of our Input Axis ID's (LeftGrip, RightGrip)
    private bool triggerHeld;      // stop calling our Grab methods so many dang times

    private string grip;
    private bool gripHeld;

    public GameObject collidingObject;
    public GameObject heldObject;

    private Vector3 handVelocity;
    private Vector3 oldHandPosition;
    private Vector3 handAngularVelocity;
    private Vector3 oldHandRotation;

    // Awake is used for Initialization
    void Awake()
    {
        if (isLeftHand)     // short hand for (isLeftHand == true)
        {
            trigger = "LeftTrigger";
        }
        else
        {
            trigger = "RightTrigger";
        }
    }

    private void OnTriggerStay(Collider thingwecollidedwith)
    {
        if (thingwecollidedwith.GetComponent<Rigidbody>())
        {
            collidingObject = thingwecollidedwith.gameObject;
        }        
    }
    private void OnTriggerExit(Collider thingwecollidedwith)
    {
        if(thingwecollidedwith == collidingObject)
        {
            collidingObject = null;
        }
    }

    void Update()
    {
        if (Input.GetAxis(trigger) > 0.8f && triggerHeld == false)
        {
            handAnim.SetBool("isClosing", true);
            triggerHeld = true;

            if(collidingObject != null)
            {
                heldObject = collidingObject;
                //Grab();
                AdvGrab();
            }            
        }
        if (Input.GetAxis(trigger) < 0.8f && triggerHeld == true)
        {
            handAnim.SetBool("isClosing", false);
            triggerHeld = false;

            if(heldObject != null)
            {
                //Release();
                AdvRelease();
                heldObject = null;
            }            
        }
        handVelocity = transform.position - oldHandPosition;
        oldHandPosition = transform.position;
        handAngularVelocity = transform.eulerAngles - oldHandRotation;
        oldHandRotation = transform.eulerAngles;
    }    

    private void Grab()
    {        
        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void AdvGrab()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = heldObject.GetComponent<Rigidbody>();
        fx.breakForce = 2000;
        heldObject.transform.rotation = transform.rotation;
    }
    private void Release()
    {
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.GetComponent<Rigidbody>().useGravity = true;
    }
    private void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            Destroy(GetComponent<FixedJoint>());
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            rb.velocity = handVelocity * forceMultiplier / rb.mass;
            rb.angularVelocity = handAngularVelocity * forceMultiplier / rb.mass;
        }
    }
}
