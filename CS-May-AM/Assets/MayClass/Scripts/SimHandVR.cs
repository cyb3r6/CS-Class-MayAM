using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandVR : MonoBehaviour
{
    public Animator handAnim;
    public bool isLeftHand;     // if isLeftHand is true, then the script is attached to the left hand.
    private string grip;        // to hold information of our Input Axis ID's (LeftGrip, RightGrip)

    // Awake is used for Initialization
    void Awake()
    {
        if (isLeftHand)     // short hand for (isLeftHand == true)
        {
            grip = "LeftGrip";
        }
        else
        {
            grip = "RightGrip";
        }

    }


    void Update()
    {
        if (Input.GetAxis(grip) > 0.8f)
        {
            handAnim.SetBool("isClosing", true);
        }
        if (Input.GetAxis(grip) < 0.8f)
        {
            handAnim.SetBool("isClosing", false);
        }
    }
}
