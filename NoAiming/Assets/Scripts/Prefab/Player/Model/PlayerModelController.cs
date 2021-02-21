using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelController : MonoBehaviour
{
    [Header("玩家模型存放區")]
    [SerializeField] private Sprite fullHealth;
    [SerializeField] private Sprite halfHealth;

    [Header("2D渲染器")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void TurnToFullHealth()
    {
        spriteRenderer.sprite = fullHealth;
        transform.localScale = new Vector3(2, 2, 1);
    }

    public void TurnToHalfHealth()
    {
        spriteRenderer.sprite = halfHealth;
        transform.localScale = new Vector3((float)0.28, (float)0.28, 1);
    }
}
