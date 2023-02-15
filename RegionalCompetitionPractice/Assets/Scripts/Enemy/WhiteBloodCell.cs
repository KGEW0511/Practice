using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject[] itemObjs;

    public int speed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigid.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            int ranItem = Random.Range(0, 4);

            GameObject item = Instantiate(itemObjs[ranItem], transform.position, transform.rotation);
            Rigidbody2D rigidItem = item.GetComponent<Rigidbody2D>();
            rigidItem.AddForce(Vector2.down * 1, ForceMode2D.Impulse);

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("BorderBullet"))
        {
            Destroy(gameObject);
        }
    }
}
