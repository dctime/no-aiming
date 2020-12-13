using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreManager : MonoBehaviour
{
    //儲存玩家點數
    private int score = 0;
    //紀錄得點數間隔
    private float time;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreEffective")
        {
            if (time >= 1)
            {
                Debug.Log(gameObject.name + " added 1 point");
                score += 1;
                time = 0;
            }
            
            time += Time.deltaTime;

        }
        else
        {
            time = 0;
        }

        if (score > 50)
        {
            score = 50;
        }
    }

    public int GetScore()
    {
        return score;
    }
}
