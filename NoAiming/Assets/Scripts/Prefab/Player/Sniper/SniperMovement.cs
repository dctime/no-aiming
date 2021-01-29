using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMovement : MonoBehaviour
{
    [Header("玩家資料設定")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform feetPos;

    [Header("控制鍵設定")]
    [SerializeField] private KeyCode moveLeftKey;
    [SerializeField] private KeyCode moveRightKey;
    [SerializeField] private KeyCode jumpKey;

    [Header("移動參數設定")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float checkGroundedLength;
    [SerializeField] private LayerMask groundLayer;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (Input.GetKey(moveLeftKey))
        {
            rb.velocity = new Vector2(rb.velocity.x - moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(moveRightKey))
        {
            rb.velocity = new Vector2(rb.velocity.x + moveSpeed, rb.velocity.y);
        }

        //for debug ChecjGrounded() LineCast
        //Debug.Log("CheckGrounded()" + CheckGrounded());
        if (Input.GetKeyDown(jumpKey) && CheckGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private bool CheckGrounded()
    {
        bool grounded = false;
        Vector3 start = feetPos.position;
        Vector3 end = new Vector3(start.x, start.y - checkGroundedLength);
        Debug.DrawLine(start, end, Color.blue);

        grounded = Physics2D.Linecast(start, end, groundLayer);
        return grounded;
    }
}
