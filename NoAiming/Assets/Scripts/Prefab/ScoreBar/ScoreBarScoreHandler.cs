using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBarScoreHandler : MonoBehaviour
{
    [Header("點數條")]
    [SerializeField] private Image scoreBar;

    [Header("獲得我方群體")]
    [SerializeField] GameObject playerGroup;
    GameObject player;

    [Header("導演(獲得最大分數使用)")]
    [SerializeField] private GameObject gameDirector;

    private void Start()
    {
        //將playerGroup裡找到是Active的物件，存入player(戰鬥開始前要先把雙方的角色先在Awake裡Active)
        for (int i = 0; i < playerGroup.transform.childCount; i++)
        {
            if (playerGroup.transform.GetChild(i).gameObject.activeSelf)
            {
                player = playerGroup.transform.GetChild(i).gameObject;
            }
        }
    }
    private void Update()
    {
        //將拿到的點數與最大點數轉換成百分率呈現在點數條上
        scoreBar.fillAmount = player.GetComponent<PlayerScoreManager>().GetScore() / (float)gameDirector.GetComponent<GameDirectorWinHandler>().GetWinScore();
    }
}
