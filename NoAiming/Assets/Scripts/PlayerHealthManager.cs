using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("一開始的生命值")]
    [SerializeField] private int startHealth;

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
        FullHealth();
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        if (transform.position.y <= -20)
        {
            health = 0;
        }
    }

}
