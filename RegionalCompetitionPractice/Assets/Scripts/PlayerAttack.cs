using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;

    float attackSpeed;
    void Start()
    {
        //bullet = GetComponent<GameObject>();
    }

    void Update()
    {
        attackSpeed += Time.deltaTime;
        if(attackSpeed >= 0.5)
        {
            attackSpeed = 0;
            BulletMake(1);
        }
    }

    void BulletMake(int n)
    {
        Instantiate(bullet);
    }
}
