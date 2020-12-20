using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayButtonHandler : MonoBehaviour
{
    public void ButtonDown()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }
}
