using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandVR : MonoBehaviour
{
    public Animator handAnim;
    public bool isLeftHand;     // if isLeftHand is true, then the script is attached to the left hand.
    private string trigger;        // to hold information of our Input Axis ID's (LeftGrip, RightGrip)

    public GameObject collidingObject;
    public GameObject heldObject;

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
        if (Input.GetAxis(trigger) > 0.8f)
        {
            handAnim.SetBool("isClosing", true);
            if(collidingObject != null)
            {
                heldObject = collidingObject;
                Grab();
            }            
        }
        if (Input.GetAxis(trigger) < 0.8f)
        {
            handAnim.SetBool("isClosing", false);
            if(heldObject != null)
            {
                Release();
                heldObject = null;
            }            
        }
    }    

    private void Grab()
    {
        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void Release()
    {
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
