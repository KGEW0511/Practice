using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;

    public float Speed;
    public bool IsTouchTop;
    public bool IsTouchBottom;
    public bool IsTouchRight;
    public bool IsTouchLeft;

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
        rigid.velocity = moveVec * Speed;
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
