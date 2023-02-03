using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigid;

    public float bulletSpeed;

    float h;
    float v;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 bulletVec = new Vector2(h,v);
        rigid.velocity = bulletVec * bulletSpeed;
    }
}
