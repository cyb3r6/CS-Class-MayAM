using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    public Transform button, up, down;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = down.position;
            audioSource.Play();
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = up.position;
        }
    }
}
