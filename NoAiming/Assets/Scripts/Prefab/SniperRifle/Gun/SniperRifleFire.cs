using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifleFire : MonoBehaviour
{
    //儲存發射鍵
    private KeyCode fireKey;

    [Header("範圍指示器")]
    [SerializeField] GameObject aimIndicator;

    [Header("範圍指示器 - 模型")]
    [SerializeField] GameObject aimIndicatorModel;

    [Header("子彈Prefab")]
    [SerializeField] private GameObject bulletType;

    [Header("槍口")]
    [SerializeField] private GameObject muzzle;

    [Header("槍枝參數")]
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;
    public float fireRateGetter()
    {
        return fireRate;
    }

    //儲存最近發射的子彈
    private GameObject currentBullet;

    [Header("獲得敵方資料")]
    [SerializeField] GameObject emenyObjectGroup;
    GameObject emenyObject;

    [Header("開火音效")]
    [SerializeField] AudioSource fireSoundEffect;

    //儲存已冷卻秒數
    private float coolDownTimer;

    public float CoolDownTimerGetter()
    {
        return coolDownTimer;
    }

    //儲存是否可以瞄準
    private bool canAim;

    //儲存是否正在瞄準
    private bool isAiming;

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
    void Update()
    {
        if (Input.GetKeyDown(fireKey) && canAim)
        {
            //開啟瞄準
            aimIndicator.SetActive(true);
            //將isAiming設為true，供發射子彈時參考
            isAiming = true;
        }

        if (Input.GetKeyUp(fireKey) && isAiming && canAim)
        {
            aimIndicator.SetActive(false);
            //產生子彈，並放到muzzle
            currentBullet = Instantiate(bulletType, muzzle.transform.position, transform.rotation);
            // --- 將產生出來的物件之元件加入一些參數 ---
            //給SniperRifleBulletMovement敵方物件
            currentBullet.GetComponent<SniperRifleBulletMovement>().emenyObject = emenyObject;
            //給SniperRifleBulletCollider敵方物件與傷害
            currentBullet.GetComponent<SniperRifleBulletCollider>().emenyObject = emenyObject;
            currentBullet.GetComponent<SniperRifleBulletCollider>().damage = damage;
            //給SniperRifleBulletMovement偏差角度
            currentBullet.GetComponent<SniperRifleBulletMovement>().angularMisalignment = aimIndicatorModel.GetComponent<SniperAimAreaIndicator>().AimIndicatorAngle_Getter();
            //播放音效
            fireSoundEffect.Play();
            //開始冷卻
            coolDownTimer = 0;
            canAim = false;
            //將isAiming設為false
            isAiming = false;
        }

        //當冷卻未完成時，冷卻
        if (coolDownTimer < fireRate && !canAim)
        {
            coolDownTimer += Time.deltaTime;
        }
        else //當冷卻已完成時，允許瞄準
        {
            canAim = true;
            coolDownTimer = fireRate;
        }

        
        
    }
}
