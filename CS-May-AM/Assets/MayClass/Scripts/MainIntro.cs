using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainIntro : MonoBehaviour
{
    public void LaunchVR()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void QuitApp()
    {
        Application.Quit();
        //SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
