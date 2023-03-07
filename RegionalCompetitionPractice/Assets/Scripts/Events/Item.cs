using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D rigid;

    public int itemNum;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (itemNum)
            {
                case 1:
                    if (player.power == 4)
                    {
                        break;
                    }
                    else
                    {
                        player.power++;
                    }
                    break;
                case 2:
                    if (player.life + 20 > 100)
                    {
                        player.life = 100;
                    }
                    else
                    {
                        player.life += 20;
                    }
                    break;
                case 3:
                    if (player.fuel - 20 < 0)
                    {
                        player.fuel = 0;
                    }
                    else
                    {
                        player.fuel -= 20;
                    }
                    break;
            }
            Destroy(gameObject);
        }
    }
}
