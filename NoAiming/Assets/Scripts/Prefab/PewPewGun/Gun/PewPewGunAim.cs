using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGunAim : MonoBehaviour
{
    [Header("獲得敵方資料")]
    [SerializeField] GameObject emenyObject;

    //相對位移
    private Vector3 relativePosition;
    //計算角度暫存區
    private float fireAngle;
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
