using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifleReloadTimerHandler : MonoBehaviour
{
    [Header("目標槍枝(查看冷卻時間)")]
    [SerializeField] GameObject gun;

    [Header("得到控制分數量的Transform(用其Scale調整)")]
    [SerializeField] private Transform controlJuiceTransform;

    [Header("得到控制顏色的SpriteRenderer")]
    [SerializeField] private SpriteRenderer controlJuiceColor;

    private void Update()
    {
        //控制冷卻條的量
        controlJuiceTransform.localScale = new Vector3(
            gun.GetComponent<SniperRifleFire>().CoolDownTimerGetter() / gun.GetComponent<SniperRifleFire>().fireRateGetter(),
            controlJuiceTransform.localScale.y,
            controlJuiceTransform.localScale.z
        );
        //控制冷卻條顏色
        if (gun.GetComponent<SniperRifleFire>().CoolDownTimerGetter() == gun.GetComponent<SniperRifleFire>().fireRateGetter())
        {
            controlJuiceColor.color = Color.green;
        }
        else
        {
            controlJuiceColor.color = Color.red;
        }
    }
}
