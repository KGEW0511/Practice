using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;

    public bool isFront;
    public bool isLeft;
    public bool isRight;

    public float power;
    public float speed;
    public float curShotDelay;
    public float maxShotDelay;
    public float health;

    public int enemyScore;

    public GameObject player;
    public GameObject bulletObj;

    GameManager gameManager;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        Move();
    }

    void Update()
    {
        Fire();
        Reload();
    }
    void Move()
    {
        if (isFront)
        {
            rigid.velocity = Vector3.down * speed;
        }
        else if (isLeft)
        {
            rigid.velocity = Vector3.left * speed;
        }
        else if (isRight)
        {
            rigid.velocity = Vector3.right * speed;
        }
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
                    GameObject bulletA = Instantiate(bulletObj, transform.position, transform.rotation);
                    Rigidbody2D rigidA = bulletA.GetComponent<Rigidbody2D>();
                    rigidA.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
                    break;
                case "B":
                    GameObject bulletB = Instantiate(bulletObj, transform.position, transform.rotation);
                    Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();
                    rigidB.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
                    break;
                case "C":
                    GameObject bulletC = Instantiate(bulletObj, transform.position, transform.rotation);
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
        spriteRenderer.color = new Color(1, 1, 1, 0);
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
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
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