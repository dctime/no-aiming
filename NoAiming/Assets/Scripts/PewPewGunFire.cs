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

    //儲存最近發射的子彈
    private GameObject currentBullet;

    [Header("敵方物件")]
    [SerializeField] private GameObject emenyObject;

    private void Awake()
    {
        //初始化fireKey
        fireKey = gameObject.transform.parent.gameObject.GetComponent<PlayerFire>().fireKey;
    }

    private void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            currentBullet = Instantiate(bulletType, muzzle.transform.position, transform.rotation);

            currentBullet.GetComponent<PewPewGunBulletMovement>().emenyObject = emenyObject;
        }
    }


}
