using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
    Rigidbody2D rigid;

    public int speed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigid.velocity = Vector2.down * speed;
    }
}
