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

    private void Update()
    {
        if (player.GetComponent<PlayerScoreManager>().GetScore() == 50)
        {
            SceneManager.LoadScene("BlueWinScene");
        }

        if (player2.GetComponent<PlayerScoreManager>().GetScore() == 50)
        {
            SceneManager.LoadScene("RedWinScene");
        }

        if (countDownTimer.GetComponent<CountDownTimerTimeCounter>().GetTime() <= 0)
        {
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
