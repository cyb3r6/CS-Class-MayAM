using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionSteps : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject forwardBackwardCanvas;

    public GameObject heatSinkCanvas;
    public List<GameObject> HSteps = new List<GameObject>();

    public GameObject Relay;
    public List<GameObject> relaySteps = new List<GameObject>();

    private List<GameObject> currentList = new List<GameObject>();
    private GameObject currentCanvas;
    private int currentStep = 0;

    public void TurnOnHeatSinkCanvas()
    {
        Debug.Log("click");
        heatSinkCanvas.SetActive(true);
        forwardBackwardCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);

        currentCanvas = heatSinkCanvas;
        currentList = HSteps;        
    }
    

    public void NextStep()
    {
        currentList[currentStep].SetActive(false);

        if(currentStep == currentList.Count - 1)
        {
            currentStep = 0;
            currentList[0].SetActive(true);
            currentCanvas.SetActive(false);
            forwardBackwardCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);

            return;
        }

        currentList[++currentStep].SetActive(true);

    }
   
}
