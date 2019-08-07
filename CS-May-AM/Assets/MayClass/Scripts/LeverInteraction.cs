using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class LeverInteraction : MonoBehaviour
{
    void Interactable()
    {
        // on interaction, rotate in the Vector3.right or new Vector3(1 * position of hand,0,0)
        

    }

    private void OnTriggerStay(Collider other)
    {
        TrackedPoseDriver controller = other.GetComponent<TrackedPoseDriver>();
        if (other)
        {
            Vector3 PositionToLookAt = new Vector3(transform.position.x, other.transform.position.y, other.transform.position.z);
            PositionToLookAt.y = Mathf.Clamp(transform.position.y, 180, 270);
            transform.LookAt(PositionToLookAt);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
