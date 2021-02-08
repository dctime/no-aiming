using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStartsButtonHandler : MonoBehaviour
{
    //當按鈕被按下時
    public void Button_Clicked()
    {
        //切換至BattleScene
        SceneManager.LoadScene("BattleScene");
    }
}
