using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    public int speed;

    public float life;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        rigid.velocity = Vector3.down * speed;
    }
    void Update()
    {
        if(rigid.position.y < 3)
        {
            rigid.velocity = Vector3.down * 0;
        }
    }
    public void OnHit(float dmg, float invincibilityTime)
    {
        life -= dmg;
        Invoke("ReturnSprite", 0.1f);

        if (life <= 0)
        {

        }
    }

    void ReturnSprite()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            
        }
    }
}
