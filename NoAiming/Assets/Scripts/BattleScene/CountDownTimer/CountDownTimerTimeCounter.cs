using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimerTimeCounter : MonoBehaviour
{
    [Header("從第幾秒開始倒數計時?")]
    [SerializeField] private float time;
    public float GetTime()
    {
        return time;
    }

    private void Update()
    {
        //倒數計時中
        time -= Time.deltaTime;
        //將剩餘時間顯示在CountDownTimer的Text上
        GetComponent<Text>().text = ((int) time).ToString();
    }

}
