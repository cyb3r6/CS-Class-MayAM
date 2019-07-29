using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTractorBeam : MonoBehaviour
{
    public float speed;
    public bool isLeftHand;
    private LineRenderer tractorBeam;
    private RaycastHit hit;
    private Transform hitTransform;
    private string grip;
    
    void Start()
    {
        tractorBeam = GetComponent<LineRenderer>();
        if (isLeftHand)
        {
            grip = "LeftGrip";
        }
    }
    
    void Update()
    {
        if(Input.GetAxis(grip) > 0.8f)
        {
            Debug.Log("click");
            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                tractorBeam.enabled = true;
                tractorBeam.SetPosition(0, transform.position);
                tractorBeam.SetPosition(1, hit.point);
                hitTransform = hit.transform;

                if (!hitTransform.GetComponent<Rigidbody>().isKinematic)
                {
                    hitTransform.position = Vector3.MoveTowards(hitTransform.position, transform.position, speed * Time.deltaTime);
                    hitTransform.GetComponent<Rigidbody>().useGravity = false;
                }
                else
                {
                    hitTransform = null;
                }
            }            
        }
        if(Input.GetAxis(grip) < 0.8f)
        {
            tractorBeam.enabled = false;
            if (hitTransform)
            {
                hitTransform.GetComponent<Rigidbody>().useGravity = true;
                hitTransform = null;
            }
        }
    }
}
