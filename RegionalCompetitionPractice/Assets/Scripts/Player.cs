using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;

    public float speed;
    public float power;
    public float maxShotDelay;
    public float curShotDelay;

    public bool IsTouchTop;
    public bool IsTouchBottom;
    public bool IsTouchRight;
    public bool IsTouchLeft;

    public GameObject bulletObjA;
    public GameObject bulletObjB;

    public int life;
    public int score;

    float h;
    float v;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        if (!Input.GetButton("Fire1"))
            return;

        if (curShotDelay < maxShotDelay)
            return;

        switch (power)
        {
            case 1:
                GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.1f, transform.rotation);
                GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.1f, transform.rotation);

                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();

                rigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject bulletRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.25f, transform.rotation);
                GameObject bulletCC = Instantiate(bulletObjB, transform.position, transform.rotation);
                GameObject bulletLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.25f, transform.rotation);

                Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();

                rigidRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 4:
                GameObject bulletRRR = Instantiate(bulletObjB, transform.position + Vector3.right * 0.25f, transform.rotation);
                GameObject bulletCCC = Instantiate(bulletObjB, transform.position, transform.rotation);
                GameObject bulletLLL = Instantiate(bulletObjB, transform.position + Vector3.left * 0.25f, transform.rotation);

                Rigidbody2D rigidRRR = bulletRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCCC = bulletCCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidLLL = bulletLLL.GetComponent<Rigidbody2D>();

                rigidRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 5:
                GameObject bulletRRRRR = Instantiate(bulletObjB, transform.position + Vector3.right * 0.5f, transform.rotation);
                GameObject bulletRRRR = Instantiate(bulletObjB, transform.position + Vector3.right * 0.25f, transform.rotation);
                GameObject bulletCCCC = Instantiate(bulletObjB, transform.position, transform.rotation);
                GameObject bulletLLLL = Instantiate(bulletObjB, transform.position + Vector3.left * 0.25f, transform.rotation);
                GameObject bulletLLLLL = Instantiate(bulletObjB, transform.position + Vector3.left * 0.5f, transform.rotation);

                Rigidbody2D rigidRRRRR = bulletRRRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRRRR = bulletRRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCCCC = bulletCCCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidLLLL = bulletLLLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidLLLLL = bulletLLLLL.GetComponent<Rigidbody2D>();

                rigidRRRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCCCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidLLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidLLLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
        }

        curShotDelay = 0;
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        if ((IsTouchRight && h == 1) || (IsTouchLeft && h == -1))
        {
            h = 0;
        }

        v = Input.GetAxisRaw("Vertical");
        if ((IsTouchTop && v == 1) || (IsTouchBottom && v == -1))
        {
            v = 0;
        }

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            animator.SetInteger("Horizontal", (int)h);
        }

        Vector2 moveVec = new Vector2(h, v);
        rigid.velocity = moveVec * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    IsTouchTop = true;
                    break;
                case "Bottom":
                    IsTouchBottom = true;
                    break;
                case "Right":
                    IsTouchRight = true;
                    break;
                case "Left":
                    IsTouchLeft = true;
                    break;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    IsTouchTop = false;
                    break;
                case "Bottom":
                    IsTouchBottom = false;
                    break;
                case "Right":
                    IsTouchRight = false;
                    break;
                case "Left":
                    IsTouchLeft = false;
                    break;

            }
        }
    }
}
