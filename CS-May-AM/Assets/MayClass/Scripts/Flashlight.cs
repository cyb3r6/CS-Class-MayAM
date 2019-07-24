using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
   void Interactable()
   {
        Light light = GetComponent<Light>();
        light.enabled = !light.enabled;
   }
}
