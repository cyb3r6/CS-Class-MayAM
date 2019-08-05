using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class Dial : MonoBehaviour
{
    private Transform handTransform;
    private Vector3 currentEuler;

    private void OnTriggerEnter(Collider other)
    {
        TrackedPoseDriver controller = other.GetComponent<TrackedPoseDriver>();
        if (controller)
        {
            currentEuler = transform.eulerAngles;
            Debug.Log(currentEuler);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        TrackedPoseDriver controller = other.GetComponent<TrackedPoseDriver>();
        if (controller)
        {
            handTransform = controller.transform;
            Vector3 handVector = handTransform.eulerAngles;

            transform.rotation = Quaternion.Euler(0, 0, -handVector.z);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
