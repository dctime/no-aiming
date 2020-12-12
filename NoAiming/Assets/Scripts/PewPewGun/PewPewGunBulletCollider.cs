using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGunBulletCollider : MonoBehaviour
{
    //儲存敵方物件(從PewPewGunFire匯入)
    [HideInInspector] public GameObject emenyObject;

    //儲存傷害(從PewPewGunFire匯入)
    [HideInInspector] public int damage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collision! " + "hit " + collider.gameObject.name);
        if (collider.gameObject.tag == "Solid Block")
        {
            Destroy(gameObject);
        }

        if (collider.gameObject == emenyObject)
        {
            Debug.Log(collider.gameObject.name + "is hit." + "caused damage " + damage);
            collider.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
