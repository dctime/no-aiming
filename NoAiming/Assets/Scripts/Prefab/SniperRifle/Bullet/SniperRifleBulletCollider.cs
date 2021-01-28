using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifleBulletCollider : MonoBehaviour
{
    //儲存敵方物件(從SniperRifleFire匯入)
    [HideInInspector] public GameObject emenyObject;

    //儲存傷害(從SniperRifleFire匯入)
    [HideInInspector] public int damage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //如果子彈撞擊的物件有"Solid Block"標籤
        //Debug.Log("collision! " + "hit " + collider.gameObject.name);
        if (collider.gameObject.tag == "Solid Block")
        {
            Destroy(gameObject);
        }

        //如果打中敵人
        if (collider.gameObject == emenyObject)
        {
            //Debug.Log(collider.gameObject.name + "is hit." + "caused damage " + damage);
            collider.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
