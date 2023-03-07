using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg;

    public bool isDmg;
    public bool isPlayerBullet;

    private void Awake()
    {
        isDmg = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BorderBullet"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Player") && isDmg)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            dmg = player.power;
            isDmg = false;
        }
        else if(collision.gameObject.CompareTag("Enemy") && isDmg)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            dmg = enemy.power;
            isDmg = false;
        }
    }
}
