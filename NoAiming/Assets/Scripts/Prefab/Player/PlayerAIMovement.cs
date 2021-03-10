using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAIMovement : MonoBehaviour
{
    [Header("手動控制移動腳本")]
    [SerializeField] private GameObject PlayerMovementScript;

    [Header("敵方玩家")]
    [SerializeField] private GameObject EmenyObject;

    private void Update()
    {
        //如果AI自動控制開啟，手動控制還是保持開啟，提出警告
        if (PlayerMovementScript.activeSelf == true)
        {
            Debug.Log("WARNING : Both Modes Are Activated!");
        }
    }
}
