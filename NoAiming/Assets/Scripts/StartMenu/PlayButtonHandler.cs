using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonHandler : MonoBehaviour
{
    public void ButtonDown()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
