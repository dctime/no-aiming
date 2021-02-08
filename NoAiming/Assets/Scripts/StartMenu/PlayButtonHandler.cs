using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonHandler : MonoBehaviour
{
    //當按鈕被按下
    public void ButtonDown()
    {
        //切換至SelectCharacterScene
        SceneManager.LoadScene("SelectCharacterScene");
    }
}
