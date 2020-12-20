using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonHandler : MonoBehaviour
{
    public void ButtonDown()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
