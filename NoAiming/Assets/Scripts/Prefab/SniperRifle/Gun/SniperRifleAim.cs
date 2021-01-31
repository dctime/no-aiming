using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifleAim : MonoBehaviour
{
    [Header("獲得敵方資料")]
    [SerializeField] GameObject emenyObjectGroup;
    GameObject emenyObject;

    //相對位移
    private Vector3 relativePosition;
    //計算角度暫存區
    private float fireAngle;

    private void Start()
    {
        //將emenyObjectGroup裡找到是Active的物件，存入emenyObject(戰鬥開始前要先把雙方的角色先在Awake裡Active)
        for (int i = 0; i < emenyObjectGroup.transform.childCount; i++)
        {
            if (emenyObjectGroup.transform.GetChild(i).gameObject.activeSelf)
            {
                emenyObject = emenyObjectGroup.transform.GetChild(i).gameObject;
            }
        }
        
    }
    private void Update()
    {

        //計算角度
        relativePosition = emenyObject.transform.position - transform.position;

        fireAngle = Mathf.Atan(relativePosition.y / relativePosition.x) / Mathf.PI * 180;

        if (relativePosition.x < 0)
        {
            fireAngle += 180;
        }
        else if (relativePosition.y < 0)
        {
            fireAngle += 360;
        }

        //Debug.Log("fireAngle" + fireAngle);

        //旋轉槍枝
        transform.eulerAngles = new Vector3(0, 0, fireAngle);
    }
}
