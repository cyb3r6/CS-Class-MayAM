using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float? counter; // -inf to + inf, 0 NOT null
    public Text displayCounter;
    public bool toggle;
    public int value;
    
    void Update()
    {
        if (toggle)
        {
            counter = value;
            toggle = false;
        }

        if (counter.HasValue)
        {
            counter -= Time.deltaTime;

            //displayCounter.text = Mathf.Round(counter.Value).ToString();
            displayCounter.text = counter.Value.ToString("F2");

            if(counter.Value < 0f)
            {
                displayCounter.text = "0";
                counter = null;
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
        }
    }
}
