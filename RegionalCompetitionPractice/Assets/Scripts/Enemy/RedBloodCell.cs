using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour
{
    Rigidbody2D rigid;
    Player player;

    public int painPower;
    public int speed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigid.velocity = Vector2.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            player.pain += painPower;
        }
    }
}
