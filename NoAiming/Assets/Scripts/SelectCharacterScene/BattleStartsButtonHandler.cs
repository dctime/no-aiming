using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStartsButtonHandler : MonoBehaviour
{
    public void Button_Clicked()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
