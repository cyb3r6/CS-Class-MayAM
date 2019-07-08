using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMay : MonoBehaviour
{
    public float moveSpeed = 5.5f;
    public float turnSpeed = 0.001f;
    public float movementForce = 50f;

    void Start()
    {
        
    }

    // Update is called 90 times/second
    void Update()
    {
        #region Translational Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            rb.AddForce(Vector3.up * movementForce);
        }
        #endregion

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed);
        /*
        if(Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey(KeyCode.I))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed);
        }
        */
    }
}
