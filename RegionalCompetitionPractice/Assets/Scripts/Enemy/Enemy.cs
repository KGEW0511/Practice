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
    public float bulletSpeed;

    public int enemyScore;

    public GameObject bulletObj;
    public GameObject[] itemObjs;
    public GameObject boss;

    GameObject player;
    GameManager gameManager;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        
        rigid.velocity = Vector3.down * speed;
    }

    void Update()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            Fire();
            Reload();
        }
        else
        {
            transform.Rotate(Vector3.forward * ((float)speed / 3));
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

                    Vector3 dirVecA = player.transform.position - transform.position;
                    rigidA.AddForce(dirVecA.normalized * bulletSpeed, ForceMode2D.Impulse);
                    break;
                case "B":
                    for(int i = -5; i < 6; i+=5)
                    {
                        GameObject bulletB = Instantiate(bulletObj, transform.position, transform.rotation);
                        Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();

                        Vector3 dirVecB = new Vector3(i + transform.position.x, -8f, 0) - transform.position;
                        rigidB.AddForce(dirVecB.normalized * bulletSpeed, ForceMode2D.Impulse);
                    }
                    break;
                case "C":
                    GameObject bulletC = Instantiate(bulletObj, transform.position, transform.rotation);
                    Rigidbody2D rigidC = bulletC.GetComponent<Rigidbody2D>();

                    Vector3 dirVecC = player.transform.position - transform.position;
                    rigidC.AddForce(dirVecC.normalized * bulletSpeed, ForceMode2D.Impulse);
                    break;
                case "Boss":
                    for (int i = -20; i < 21; i+=4)
                    {
                        GameObject bulletB = Instantiate(bulletObj, transform.position, transform.rotation);
                        Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();

                        Vector3 dirVecB = new Vector3(i + boss.GetComponent<Boss>().paternTime % 10 + transform.position.x, -8f, 0) - transform.position;
                        rigidB.AddForce(dirVecB.normalized * bulletSpeed, ForceMode2D.Impulse);
                    }
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

        if (health <= 0)
        {
            Player.score += enemyScore;
            ItemSpawn();
            Destroy(gameObject);
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void ItemSpawn()
    {
        int spawnRange = Random.Range(0, 6);
        int itemRange = Random.Range(0, 5);
        if(spawnRange > 4)
        {
            Instantiate(itemObjs[itemRange], transform.position, Quaternion.Euler(0, 0, 0));
        }
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