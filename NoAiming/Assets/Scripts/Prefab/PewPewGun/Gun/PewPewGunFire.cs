using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGunFire : MonoBehaviour
{
    //儲存發射鍵
    private KeyCode fireKey;

    [Header("子彈Prefab")]
    [SerializeField] private GameObject bulletType;

    [Header("槍口")]
    [SerializeField] private GameObject muzzle;

    [Header("槍枝參數")]
    [SerializeField] private float coolTime; //發射與發射的間隔
    [SerializeField] private int burstPerFire; //每次發射有幾個子彈噴出來
    [SerializeField] private float reloadTime; //彈夾重裝填的時間
    public float ReloadTimeGetter()
    {
        return reloadTime;
    }
    [SerializeField] private int damage; //每顆子彈的傷害
    [SerializeField] private int clipAmmo; //每次裝填發射次數
    public int ClipAmmoGetter()
    {
        return clipAmmo;
    }
    [SerializeField] private float bulletFireDelay; //每次發射子彈與子彈之間射擊延遲時間

    //儲存重裝彈時間
    private float reloadingTime;

    public float ReloadingTimeGetter()
    {
        return reloadingTime;
    }

    //儲存冷卻的時間
    private float coolingTime;

    //儲存每顆子彈與每顆子彈的發射間隔時間
    private float bulletFireDelayingTime;

    //儲存剩餘發射數
    private int clipAmmoLeft;
    public int ClipAmmoLeftGetter()
    {
        return clipAmmoLeft;
    }

    //儲存此發射剩餘子彈數
    private int burstLeft;


    //儲存最近發射的子彈
    private GameObject currentBullet;

    [Header("獲得敵方資料")]
    [SerializeField] GameObject emenyObjectGroup;
    GameObject emenyObject;

    [Header("開火音效")]
    [SerializeField] AudioSource fireSoundEffect;

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

        //初始化fireKey
        fireKey = gameObject.transform.parent.parent.gameObject.GetComponent<PlayerFire>().fireKey;
    }

    private void Update()
    {
        //如果按下發射鍵，冷卻時間完成，裝填完成，也延遲完成
        if (Input.GetKey(fireKey) && coolingTime == coolTime && reloadingTime == reloadTime && bulletFireDelayingTime == bulletFireDelay)
        {
            //產生子彈，並放到muzzle
            currentBullet = Instantiate(bulletType, muzzle.transform.position, transform.rotation);
            // --- 將產生出來的物件之元件加入一些參數 ---
            //給PewPewGunBulletCollider敵方物件
            currentBullet.GetComponent<PewPewGunBulletMovement>().emenyObject = emenyObject;
            //給PewPewGunBulletCollider敵方物件與傷害
            currentBullet.GetComponent<PewPewGunBulletCollider>().emenyObject = emenyObject;
            currentBullet.GetComponent<PewPewGunBulletCollider>().damage = damage;
            //播放音效
            fireSoundEffect.Play();
            //此發射少一顆子彈
            burstLeft = burstLeft - 1;
            //開始延遲
            bulletFireDelayingTime = 0;
            
            //如果此發射沒有子彈了，開始冷卻，並減少一次的發射
            if (burstLeft == 0)
            {
                coolingTime = 0;
                clipAmmoLeft -= 1;

                //如果已沒有發射次數，開始裝填
                if (clipAmmoLeft == 0)
                {
                    reloadingTime = 0;
                }
            }

        }

        //如果需要冷卻，冷卻
        if (coolingTime < coolTime)
        {
            coolingTime += Time.deltaTime;
            //將此發射剩餘子彈數弄到設定值
            burstLeft = burstPerFire;
        }
        else
        {
            coolingTime = coolTime;
        }

        //如果需要裝填，裝填
        if (reloadingTime < reloadTime)
        {
            reloadingTime += Time.deltaTime;
            //將剩餘發射數弄到設定值
            clipAmmoLeft = clipAmmo;
        }
        else
        {
            reloadingTime = reloadTime;
        }

        //如果需要延遲，延遲
        if (bulletFireDelayingTime < bulletFireDelay)
        {
            bulletFireDelayingTime += Time.deltaTime;
        }
        else
        {
            bulletFireDelayingTime = bulletFireDelay;
        }
    }


}
