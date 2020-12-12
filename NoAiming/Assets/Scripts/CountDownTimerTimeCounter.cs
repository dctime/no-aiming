using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimerTimeCounter : MonoBehaviour
{
    [Header("從第幾秒開始倒數計時?")]
    [SerializeField] private float time;

    private void Update()
    {
        time -= Time.deltaTime;

        GetComponent<Text>().text = ((int) time).ToString();
    }
}
