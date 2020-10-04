using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backpress : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("MainMenu");
    }
}
