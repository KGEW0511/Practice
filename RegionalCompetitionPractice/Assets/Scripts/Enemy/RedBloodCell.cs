using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour
{
    Rigidbody2D rigid;


    public float painPower;

    public int speed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigid.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            GameObject.Find("Player").GetComponent<Player>().pain -= painPower;
            Destroy(gameObject);
        }
    }
}
