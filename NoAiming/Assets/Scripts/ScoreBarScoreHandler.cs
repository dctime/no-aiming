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

    private void Update()
    {
        scoreBar.fillAmount = player.GetComponent<PlayerScoreManager>().GetScore() / 100f;
    }
}
