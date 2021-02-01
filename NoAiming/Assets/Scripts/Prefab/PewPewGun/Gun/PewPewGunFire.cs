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
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;

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
        if (Input.GetKeyDown(fireKey))
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

        }
    }


}
