using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("一開始的生命值")]
    [SerializeField] private int startHealth;

    [Header("死亡特效")]
    [SerializeField] private GameObject deathParticle;

    //真正的生命值
    private int health;
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void FullHealth()
    {
        health = startHealth;
    }

    private void Start()
    {
        //當重生時，生命值全滿
        FullHealth();
    }

    private void Update()
    {
        //如果生命值是零(或小於)
        if (health <= 0)
        {
            //播放死亡特效
            Instantiate(deathParticle,transform);
            //玩家死亡
            gameObject.SetActive(false);
        }

        //如果掉太下去了
        if (transform.position.y <= -20)
        {
            //讓虛空殺死他
            health = 0;
        }
    }

}
