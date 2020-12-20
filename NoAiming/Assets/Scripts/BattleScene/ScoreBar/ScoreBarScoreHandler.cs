using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBarScoreHandler : MonoBehaviour
{
    [Header("點數條")]
    [SerializeField] private Image scoreBar;

    [Header("目標玩家物件")]
    [SerializeField] private GameObject player;

    [Header("導演(獲得最大分數使用)")]
    [SerializeField] private GameObject gameDirector;

    private void Update()
    {
        //將拿到的點數與最大點數轉換成百分率呈現在點數條上
        scoreBar.fillAmount = player.GetComponent<PlayerScoreManager>().GetScore() / (float)gameDirector.GetComponent<GameDirectorWinHandler>().GetWinScore();
    }
}
