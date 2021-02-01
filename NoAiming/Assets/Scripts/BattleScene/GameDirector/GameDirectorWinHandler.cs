using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirectorWinHandler : MonoBehaviour
{
    [Header("雙方玩家群體")]
    [SerializeField] private GameObject player1Group;
    [SerializeField] private GameObject player2Group;
    private GameObject player1;
    private GameObject player2;

    [Header("倒數計時器")]
    [SerializeField] private GameObject countDownTimer;

    [Header("勝利需要點數")]
    [SerializeField] private int winScore;
    public int GetWinScore()
    {
        return winScore;
    }

    private void Start()
    {
        //將player1Group裡找到是Active的物件，存入player1(戰鬥開始前要先把雙方的角色先在Awake裡Active)
        for (int i = 0; i < player1Group.transform.childCount; i++)
        {
            if (player1Group.transform.GetChild(i).gameObject.activeSelf)
            {
                player1 = player1Group.transform.GetChild(i).gameObject;
            }
        }

        //將player2Group裡找到是Active的物件，存入player2(戰鬥開始前要先把雙方的角色先在Awake裡Active)
        for (int i = 0; i < player2Group.transform.childCount; i++)
        {
            if (player2Group.transform.GetChild(i).gameObject.activeSelf)
            {
                player2 = player2Group.transform.GetChild(i).gameObject;
            }
        }
    }
    private void Update()
    {
        //如果藍隊獲得的分數已是勝利的分數
        if (player1.GetComponent<PlayerScoreManager>().GetScore() == GetWinScore())
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
            if (player1.GetComponent<PlayerScoreManager>().GetScore() >= player2.GetComponent<PlayerScoreManager>().GetScore())
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
