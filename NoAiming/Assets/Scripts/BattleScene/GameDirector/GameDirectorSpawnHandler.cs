using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorSpawnHandler : MonoBehaviour
{
    [Header("雙方玩家群體")]
    [SerializeField] private GameObject player1Group;
    [SerializeField] private GameObject player2Group;
    private GameObject player1;
    private GameObject player2;

    [Header("重生時間")]
    [SerializeField] private float player1RespawnTime;
    [SerializeField] private float player2RespawnTime;

    [Header("重生地點")] //this thing must be fixed, DRY
    [SerializeField] private GameObject player1StartPos1;
    [SerializeField] private GameObject player1StartPos2;
    [SerializeField] private GameObject player2StartPos1;
    [SerializeField] private GameObject player2StartPos2;

    //雙方玩家重生倒數計時
    private float player1CurrentRespawnTime;
    private float player2CurrentRespawnTime;

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

        //當重生時，將重生倒數歸零
        player1CurrentRespawnTime = 0;
        player2CurrentRespawnTime = 0;
    }
    private void Update()
    {
        //當玩家死掉時
        if (player1.activeSelf == false)
        {
            //回復生命
            player1.GetComponent<PlayerHealthManager>().FullHealth();
            //開始倒數重生時間
            player1CurrentRespawnTime += Time.deltaTime;
            if (player1CurrentRespawnTime >= player1RespawnTime)
            {
                //Debug.Log("player Respawn!");
                if (Random.value <= 0.5)
                {
                    player1.transform.position = player1StartPos1.transform.position; // this thing must be fixed
                    Debug.Log("Player1 spawn at pos1");
                }
                else
                {
                    player1.transform.position = player1StartPos2.transform.position; // this thing must be fixed
                    Debug.Log("Player1 spawn at pos2");
                }

                //讓他可以被看到
                player1.SetActive(true);
                player1CurrentRespawnTime = 0;
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
                if (Random.value <= 0.5)
                {
                    player2.transform.position = player2StartPos1.transform.position; // this thing must be fixed
                    Debug.Log("Player2 spawn at pos1");
                }
                else
                {
                    player2.transform.position = player2StartPos2.transform.position; // this thing must be fixed
                    Debug.Log("Player2 spawn at pos2");
                }
                player2.SetActive(true);
                player2CurrentRespawnTime = 0;
            }
        }
    }
}
