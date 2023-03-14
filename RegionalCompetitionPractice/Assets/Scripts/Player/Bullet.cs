using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BorderBullet"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("EnemyBullet") && gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
        }

        if (gameObject.name == "Skill1(Clone)")
        {
            if (collision.gameObject.CompareTag("BossBullet"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
