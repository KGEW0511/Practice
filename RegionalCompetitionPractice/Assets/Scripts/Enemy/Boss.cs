using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D rigid;

    int direction;

    public float paternTime;
    public int speed;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(paternTime > 20)
        {
            direction = 1;
        }
        else if(paternTime < -20)
        {
            direction = 0;
        }

        if(direction == 1)
        {
            paternTime -= Time.deltaTime * 2;
        }
        else if(direction == 0)
        {
            paternTime += Time.deltaTime * 2;
        }

        if(rigid.position.y < 3)
        {
            rigid.velocity = Vector3.down * 0;
        }
    }
    void ReturnSprite()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            
        }
    }
}
