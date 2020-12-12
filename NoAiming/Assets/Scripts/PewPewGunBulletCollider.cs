using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGunBulletCollider : MonoBehaviour
{
    //儲存敵方物件(從PewPewGunFire匯入)
    [HideInInspector] public GameObject emenyObject;

    //儲存傷害(從PewPewGunFire匯入)
    [HideInInspector] public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision! " + "hit " + collision.gameObject.name);
        if (collision.gameObject.tag == "Solid Block")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject == emenyObject)
        {
            Debug.Log(collision.gameObject.name + "is hit." + "caused damage " + damage);
            collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
