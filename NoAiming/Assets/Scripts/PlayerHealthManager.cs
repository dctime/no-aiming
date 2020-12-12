using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("一開始的生命值")]
    [SerializeField] private int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
