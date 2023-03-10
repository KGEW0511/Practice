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
    static public float difficulty;

    public bool IsInvincibility;

    public Sprite[] sprites;
    public AudioClip hitSound;
    public AudioClip shootSound;
    public GameObject[] sBulletObjs;
    public GameObject[] bBulletObjs;
    public SaveManager manager;

    static public int score;
    static public int spriteColor;

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
        Fuel();
    }
    void Fuel()
    {
        fuel -= Time.deltaTime;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void Fire()
    {
        if (!Input.GetKeyDown(KeyCode.D))
            return;

        if (curShotDelay < maxShotDelay)
            return;

        switch (power)
        {
            case 1:
                GameObject bullet = Instantiate(sBulletObjs[manager.spriteColor], transform.position, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject bulletL = Instantiate(sBulletObjs[manager.spriteColor], transform.position + new Vector3(-0.1f, 0, 0), transform.rotation);
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                rigidL.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

                GameObject bulletR = Instantiate(sBulletObjs[manager.spriteColor], transform.position + new Vector3(0.1f, 0, 0), transform.rotation);
                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                rigidR.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject bulletM = Instantiate(bBulletObjs[manager.spriteColor], transform.position, transform.rotation);
                Rigidbody2D rigidM = bulletM.GetComponent<Rigidbody2D>();
                rigidM.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                break;
            case 4:
                GameObject bulletLL = Instantiate(bBulletObjs[manager.spriteColor], transform.position + new Vector3(-0.2f, 0, 0), transform.rotation);
                Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                rigidLL.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

                GameObject bulletRR = Instantiate(bBulletObjs[manager.spriteColor], transform.position + new Vector3(0.2f, 0, 0), transform.rotation);
                Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                rigidRR.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                break;
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

    public void OnHit(float dmg, float invincibilityTime)
    {
        audioSource.clip = hitSound;
        audioSource.loop = false;
        audioSource.Play();
        life -= dmg;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        IsInvincibility = true;
        Invoke("Recovery", invincibilityTime);

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
            OnHit(bullet.dmg, 1f);
            Destroy(collision.gameObject);
        }
    }
}