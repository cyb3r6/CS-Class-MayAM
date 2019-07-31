using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public Light light;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("pushed");
        if(collision.collider.tag == "pushbutton")
        {
            light.enabled = !light.enabled;
        }
    }

}
