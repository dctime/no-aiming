using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirectorWinHandler : MonoBehaviour
{
    [Header("玩家雙方")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject player2;

    [Header("倒數計時器")]
    [SerializeField] private GameObject countDownTimer;

    [Header("勝利需要點數")]
    [SerializeField] private int winScore;
    public int GetWinScore()
    {
        return winScore;
    }

    private void Update()
    {
        //如果藍隊獲得的分數已是勝利的分數
        if (player.GetComponent<PlayerScoreManager>().GetScore() == GetWinScore())
        {
            //切換到藍隊獲勝場景
            SceneManager.LoadScene("BlueWinScene");
        }

        //如果紅隊獲得的分數已是勝利的分數
        if (player2.GetComponent<PlayerScoreManager>().GetScore() == GetWinScore())
        {
            //切換到紅隊獲勝場景
            SceneManager.LoadScene("RedWinScene");
        }

        //如果比賽時間已到
        if (countDownTimer.GetComponent<CountDownTimerTimeCounter>().GetTime() <= 0)
        {
            //誰分數最多誰獲勝
            if (player.GetComponent<PlayerScoreManager>().GetScore() >= player2.GetComponent<PlayerScoreManager>().GetScore())
            {
                SceneManager.LoadScene("BlueWinScene");
            }
            else
            {
                SceneManager.LoadScene("RedWinScene");
            }
        }
    }
}
