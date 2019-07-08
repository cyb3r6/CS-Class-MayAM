using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAnimTrigger : MonoBehaviour
{
    public Animator bridgeAnimator;

    private void OnTriggerEnter(Collider other)
    {
        bridgeAnimator.SetTrigger("BridgeUp");
    }
}
