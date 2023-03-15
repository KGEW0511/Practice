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
    public float bulletSpeed;
    public float health;
    public float enemyScore;

    public GameObject Razer;
    public GameObject bulletObj;
    public GameObject[] itemObjs;
    public GameObject boss;

    public int bossPaternCount;

    GameObject player;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        
        rigid.velocity = Vector3.down * speed;

        health *= Player.difficulty;
        power *= Player.difficulty;
        bulletSpeed *= Player.difficulty;
        speed *= Player.difficulty;
        enemyScore *= Player.difficulty;

        health *= (GameManager.stageIndex + 1);
        power *= (GameManager.stageIndex + 1);
        bulletSpeed *= (GameManager.stageIndex + 1);
        speed *= (GameManager.stageIndex + 1);
        enemyScore *= (GameManager.stageIndex + 1);
    }

    void Update()
    {
        if (gameObject.CompareTag("Enemy") || gameObject.CompareTag("Boss"))
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
                    for(int i = -5; i < 6; i+=3)
                    {
                        GameObject bulletB = Instantiate(bulletObj, transform.position, transform.rotation);
                        Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();

                        Vector3 dirVecB = new Vector3(i + transform.position.x, -8f, 0) - transform.position;
                        rigidB.AddForce(dirVecB.normalized * bulletSpeed, ForceMode2D.Impulse);
                    }
                    break;
                case "C":
                    for (int i = -2; i < 4; i += 5)
                    {
                        GameObject bulletC = Instantiate(bulletObj, transform.position, transform.rotation);
                        Rigidbody2D rigidC = bulletC.GetComponent<Rigidbody2D>();

                        Vector3 dirVecC = new Vector3(i + transform.position.x, -8f, 0) - transform.position;
                        rigidC.AddForce(dirVecC.normalized * bulletSpeed, ForceMode2D.Impulse);
                    }
                    break;
                case "Boss":
                    for (int i = -20; i < 21; i+=4)
                    {
                        GameObject bulletB = Instantiate(bulletObj, transform.position, transform.rotation);
                        Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();

                        Vector3 dirVecB = new Vector3(i + boss.GetComponent<Boss>().paternTime1 % 10 + transform.position.x, -8f, 0) - transform.position;
                        rigidB.AddForce(dirVecB.normalized * bulletSpeed, ForceMode2D.Impulse);
                    }
                    break;
                case "BossEnd":
                    for (int i = -20; i < 21; i += 3)
                    {
                        GameObject bulletB = Instantiate(bulletObj, transform.position, transform.rotation);
                        Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();
                            
                        Vector3 dirVecB = new Vector3(i + boss.GetComponent<Boss>().paternTime1 % 10 + transform.position.x, -8f, 0) - transform.position;
                        rigidB.AddForce(dirVecB.normalized * bulletSpeed, ForceMode2D.Impulse);
                    }
                    bossPaternCount++;



                    if(bossPaternCount >= 5)
                    {
                        for (int i = -6; i < 7; i += 3)
                        {
                            GameObject RazerM = Instantiate(Razer, new Vector3(transform.position.x + (i * 1), transform.position.y - 5, transform.position.z)
                                , transform.rotation);
                            Destroy(RazerM, 1f);
                        }
                        bossPaternCount = 0;
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
            if (gameObject.CompareTag("Boss"))
            {
                Instantiate(itemObjs[0], transform.position, Quaternion.Euler(0, 0, 0));
                GameManager.StageClear();
            }
            else
            {
                ItemSpawn();
            }
            Destroy(gameObject);
        }
    }
    void ReturnSprite()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    
    void ItemSpawn()
    {
        int spawnRange = Random.Range(0, 15);
        int itemRange = Random.Range(0, 5);
        if(spawnRange > 13)
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