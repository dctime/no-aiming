using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGunReloadTimerHandler : MonoBehaviour
{
    [Header("目標槍枝(查看冷卻時間，發數次數等等)")]
    [SerializeField] GameObject gun;

    [Header("得到控制分數量的Transform(用其Scale調整)")]
    [SerializeField] private Transform controlJuiceTransform;

    [Header("得到控制顏色的SpriteRenderer")]
    [SerializeField] private SpriteRenderer controlJuiceColor;

    //是否正在裝填
    private bool isReloading;

    private void Awake()
    {
        //一開始是裝填模式
        isReloading = true;
        //顏色調成紅色
        controlJuiceColor.color = Color.red;
    }
    private void Update()
    {
        //如果正在裝填
        if (isReloading)
        {
            //切換成裝填顯示模式
            controlJuiceTransform.localScale = new Vector3(gun.GetComponent<PewPewGunFire>().ReloadingTimeGetter() / gun.GetComponent<PewPewGunFire>().ReloadTimeGetter(),
                controlJuiceTransform.localScale.y,
                controlJuiceTransform.localScale.z);

            //如果裝填完畢
            if (gun.GetComponent<PewPewGunFire>().ReloadingTimeGetter() == gun.GetComponent<PewPewGunFire>().ReloadTimeGetter())
            {
                //切換成顯示發射數量模式
                isReloading = false;
                //顏色調成綠色
                controlJuiceColor.color = Color.green;
            }
        }
        else //如果在發射中
        {
            //切換成顯示發射數量模式
            controlJuiceTransform.localScale = new Vector3((float) gun.GetComponent<PewPewGunFire>().ClipAmmoLeftGetter() / (float) gun.GetComponent<PewPewGunFire>().ClipAmmoGetter(),
                controlJuiceTransform.localScale.y,
                controlJuiceTransform.localScale.z);

            //如果正在裝填
            if (gun.GetComponent<PewPewGunFire>().ReloadingTimeGetter() < gun.GetComponent<PewPewGunFire>().ReloadTimeGetter())
            {
                //切換成裝填模式
                isReloading = true;
                //顏色調成紅色
                controlJuiceColor.color = Color.red;
            }
        }
    }
}
