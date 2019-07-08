using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    public int shotsFired;
    public Text monolithText;

    // check how many shots have been fired
    // print to the text
    void Update()
    {
        monolithText.text = "Shots Fired: " + shotsFired;
    }
}
