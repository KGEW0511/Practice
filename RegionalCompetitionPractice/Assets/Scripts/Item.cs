using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D rigid;
    Player player;

    public int itemNum;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (itemNum)
        {
            case 1:
                if(player.power == 5)
                {
                    break;
                }
                else
                {
                    player.power++;
                }
                break;
            case 2:
                if(player.life + 20 > 100)
                {
                    player.life = 100;
                }
                else
                {
                    player.life += 20;
                }
                break;
            case 3:
                if (player.pain - 20 < 0)
                {
                    player.pain = 0;
                }
                else
                {
                    player.pain -= 20;
                }
                break;
        }
    }
}
