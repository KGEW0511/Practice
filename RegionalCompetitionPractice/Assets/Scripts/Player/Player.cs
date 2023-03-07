using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    public float speed;
    public float power;
    public float maxShotDelay;
    public float curShotDelay;
    public float fuel;
    public float life;

    public bool IsInvincibility;

    public Sprite[] sprites;
    public AudioClip hitSound;
    public AudioClip shootSound;
    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public SaveManager manager;

    public int score;

    float h;
    float v;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        manager = GameObject.FindObjectOfType<SaveManager>();
        spriteRenderer.sprite = sprites[manager.spriteColor];
    }

    void Update()
    {
        Move();
        Fire();
        Reload();
    }
    
    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void Fire()
    {
        if (!Input.GetKey(KeyCode.D))
            return;

        if (curShotDelay < maxShotDelay)
            return;

        switch (power)
        {
            
        }
        audioSource.clip = shootSound;
        audioSource.loop = false;
        audioSource.Play();

        curShotDelay = 0;
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            h = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            h = -1;
        }
        else h = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            v = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            v = -1;
        }
        else
        {
            v = 0;
        }

        Vector2 moveVec = new Vector2(h, v);
        rigid.velocity = moveVec * speed;
    }

    void OnHit(float dmg)
    {
        audioSource.clip = hitSound;
        audioSource.loop = false;
        audioSource.Play();
        life -= dmg;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        IsInvincibility = true;
        Invoke("Recovery", 1.5f);

        if (life <= 0)
        {
            
        }
    }

    void Recovery()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        IsInvincibility = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && !IsInvincibility)
        {
            switch (collision.gameObject.name)
            {
                case "Enemy A":
                    break;
                case "Enemy B":
                    break;
                case "Enemy C":
                    break;
                case "Boss":
                    break;
            }
        }
        else if(collision.gameObject.tag == "EnemyBullet" && !IsInvincibility)
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);
            Destroy(collision.gameObject);
        }
    }
}