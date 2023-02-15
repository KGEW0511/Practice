using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;

    public float power;
    public float speed;
    public float curShotDelay;
    public float maxShotDelay;
    public float health;

    public int enemyScore;

    public Sprite[] sprites;
    public GameObject player;
    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject bulletObjC;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    void Update()
    {
        Fire();
        Reload();
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void Fire()
    {
        if (curShotDelay > maxShotDelay)
        {
            switch (enemyName)
            {
                case "A":
                    GameObject bulletA = Instantiate(bulletObjA, transform.position, transform.rotation);
                    Rigidbody2D rigid = bulletA.GetComponent<Rigidbody2D>();
                    rigid.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
                    break;
                case "B":
                    GameObject bulletB = Instantiate(bulletObjB, transform.position, transform.rotation);
                    Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();
                    rigidB.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
                    break;
                case "C":
                    GameObject bulletC = Instantiate(bulletObjC, transform.position, transform.rotation);
                    Rigidbody2D rigidC = bulletC.GetComponent<Rigidbody2D>();
                    rigidC.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
                    break;
            }
            curShotDelay = 0;
        }
    }

    void OnHit(float dmg)
    {
        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if(health <= 0)
        {
            Player playerLogic = player.GetComponent<Player>();
            playerLogic.score += enemyScore; 
            Destroy(gameObject);
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BorderBullet"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);

            Destroy(collision.gameObject);
        }
    }
}