using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScoreManager : MonoBehaviour
{
    //儲存玩家點數
    private int score = 0;
    public int GetScore()
    {
        return score;
    }
    //紀錄得點數間隔
    private float time;

    [Header("導演(獲得最大分數使用)")]
    [SerializeField] private GameObject gameDirector;

    [Header("得分音效")]
    [SerializeField] private AudioSource scoreSoundEffect;


    private void OnTriggerStay2D(Collider2D collision)
    {
        //如果停留在點數地板上
        if (collision.gameObject.tag == "ScoreEffective")
        {
            //每停留一秒
            if (time >= 1)
            {
                //分數加一
                //Debug.Log(gameObject.name + " added 1 point");
                score += 1;
                time = 0;
                //播放得分音效
                scoreSoundEffect.Play();
            }

            time += Time.deltaTime;

        }
        //如果離開分數地板，加分緩衝器歸零
        else
        {
            time = 0;
        }

        //如果獲得的分數已大於最大分數，將獲得的分數設定為最大分數
        if (score > gameDirector.GetComponent<GameDirectorWinHandler>().GetWinScore())
        {
            score = gameDirector.GetComponent<GameDirectorWinHandler>().GetWinScore();
        }
    }
}
