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
    static public float difficulty = -1;
    static public float score;
    public float skill1Time;
    public float skill2Time;


    public bool IsInvincibility;

    public SkillUI Skill;
    public Sprite[] sprites;
    public AudioClip hitSound;
    public AudioClip shootSound;
    public GameObject skill1;
    public GameObject[] sBulletObjs;
    public GameObject[] bBulletObjs;

    public int skill1Count = 3;
    public int skill2Count = 3;
    static public int spriteColor = -1;

    float h;
    float v;
    void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprites[spriteColor];
    }

    void Update()
    {
        Move();
        Fire();
        Reload();
        Fuel();
        Skill1();
        Skill2();
    }
    void Fuel()
    {
        fuel -= Time.deltaTime;
        if(fuel <= 0)
        {
            GameManager.GameOver();
        }
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
                GameObject bullet = Instantiate(sBulletObjs[spriteColor], transform.position, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject bulletM = Instantiate(bBulletObjs[spriteColor], transform.position, transform.rotation);
                Rigidbody2D rigidM = bulletM.GetComponent<Rigidbody2D>();
                rigidM.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject bulletL = Instantiate(sBulletObjs[spriteColor], transform.position + new Vector3(-0.1f, 0, 0), transform.rotation);
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                rigidL.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

                GameObject bulletR = Instantiate(sBulletObjs[spriteColor], transform.position + new Vector3(0.1f, 0, 0), transform.rotation);
                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                rigidR.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                break;
            case 4:
                GameObject bulletLL = Instantiate(bBulletObjs[spriteColor], transform.position + new Vector3(-0.2f, 0, 0), transform.rotation);
                Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                rigidLL.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

                GameObject bulletRR = Instantiate(bBulletObjs[spriteColor], transform.position + new Vector3(0.2f, 0, 0), transform.rotation);
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

    void Skill1()
    {
        skill1Time += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.W) && (skill1Time < 10f || skill1Count == 0))
        {
            Skill.NoSkill1();
        }
        else if (Input.GetKeyDown(KeyCode.W) && skill1Time > 10f && skill1Count > 0)
        {
            if (life + 20 > 100)
            {
                life = 100;
            }
            else
            {
                life += 20;
            }

            if (fuel + 20 > 100)
            {
                fuel = 100;
            }
            else
            {
                fuel += 20;
            }
            skill1Time = 0;
            skill1Count--;
        }
    }

    void Skill2()
    {
        skill2Time += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.E) && (skill2Time < 10 || skill2Count == 0))
        {
            Skill.NoSkill2();
        }
        else if (Input.GetKeyDown(KeyCode.E) && skill2Time > 10 && skill2Count > 0)
        {
            GameObject a = Instantiate(skill1, transform.position, transform.rotation);
            skill2Time = 0;
            Invoke("SkillDestroy", 1f);
            skill2Count--;
        }
    }
    public void SkillDestroy()
    {
        Destroy(GameObject.Find("Skill1(Clone)"));
    }
    public void OnHit(float dmg, float invincibilityTime)
    {
        if (!IsInvincibility)
        {
            audioSource.clip = hitSound;
            audioSource.loop = false;
            audioSource.Play();
            life -= dmg;
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            IsInvincibility = true;
            Invoke("Recovery", invincibilityTime);
        }

        if (life <= 0)
        {
            GameManager.GameOver();
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
            OnHit(collision.gameObject.GetComponent<Enemy>().power, 1f);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "BossBullet"  && !IsInvincibility)
        {
            OnHit(collision.gameObject.GetComponent<Bullet>().dmg, 1f);
            Destroy(collision.gameObject);
        }
    }
}