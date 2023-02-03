using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;

    public float Speed;

    float h;
    float v;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        animator.SetInteger("Horizontal",(int)h);
    }

    void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(h, v);
        rigid.velocity = moveVec * Speed;
    }
}
