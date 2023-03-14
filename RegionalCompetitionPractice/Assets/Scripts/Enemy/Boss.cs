using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Enemy enemy;
    public Slider hpBar;
    public Text hpText;
    Rigidbody2D rigid;

    public float curHp;
    public float maxHp;
    public float paternTime1;
    public float paternTime2;

    public int speed;
    int direction;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        maxHp = GetComponent<Enemy>().health;
    }
    void Update()
    {
        PaternTime();

        curHp = GetComponent<Enemy>().health;
        hpBar.value = curHp / maxHp;
        hpText.text = string.Format("{0}%", (curHp / maxHp) * 100);
    }

    void PaternTime()
    {
        if (paternTime1 > 20)
        {
            direction = 1;
        }
        else if (paternTime1 < -20)
        {
            direction = 0;
        }

        if (direction == 1)
        {
            paternTime1 -= Time.deltaTime * 2;
        }
        else if (direction == 0)
        {
            paternTime1 += Time.deltaTime * 2;
        }

        if (rigid.position.y < 3)
        {
            rigid.velocity = Vector3.down * 0;
        }
    }
}
