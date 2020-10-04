using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArGUI : MonoBehaviour
{
    public void GoToARCamera()
    {
        Application.LoadLevel("ArScene");
    }

    public void GoToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void GoToHelp()
    {
        Application.LoadLevel("Help");
    }

    public void GoToInfoMelaka()
    {
        Application.LoadLevel("InfoMelaka");
    }

    public void GoToExit()
    {
        Application.Quit();
    }
}
