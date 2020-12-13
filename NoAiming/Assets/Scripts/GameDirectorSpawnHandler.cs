using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorSpawnHandler : MonoBehaviour
{
    [Header("雙方玩家")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject player2;

    [Header("重生時間")]
    [SerializeField] private float playerRespawnTime;
    [SerializeField] private float player2RespawnTime;

    [Header("重生地點")]
    [SerializeField] private GameObject playerStartPos;
    [SerializeField] private GameObject player2StartPos;

    //雙方玩家重生倒數計時
    private float playerCurrentRespawnTime;
    private float player2CurrentRespawnTime;

    private void Start()
    {
        playerCurrentRespawnTime = 0;
        player2CurrentRespawnTime = 0;
    }
    private void Update()
    {
        //當玩家死掉時
        if (player.activeSelf == false)
        {
            //回復生命
            player.GetComponent<PlayerHealthManager>().FullHealth();
            //開始倒數重生時間
            playerCurrentRespawnTime += Time.deltaTime;
            if (playerCurrentRespawnTime >= playerRespawnTime)
            {
                //Debug.Log("player Respawn!");
                //讓他可以被看到
                player.SetActive(true);
                player.transform.position = playerStartPos.transform.position;
                playerCurrentRespawnTime = 0;
            }
        }

        //當玩家二死掉時
        if (player2.activeSelf == false)
        {
            //回復生命
            player2.GetComponent<PlayerHealthManager>().FullHealth();
            //開始倒數重生時間
            player2CurrentRespawnTime += Time.deltaTime;
            //如果重生時間到了
            if (player2CurrentRespawnTime >= player2RespawnTime)
            {
                //Debug.Log("player2 respawn!");
                player2.SetActive(true);
                player2.transform.position = player2StartPos.transform.position;
                player2CurrentRespawnTime = 0;
            }
        }
    }
}
