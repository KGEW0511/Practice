using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hp_Bar : MonoBehaviour
{
    public Player player;
    public Slider hpbar;

    public Text hpText;
    public float maxHp;
    public float currenthp;

    void Awake()
    {
        maxHp = player.life;
    }

    void Update()
    {
        currenthp = player.life;
        hpbar.value = currenthp / maxHp;
        hpText.text = string.Format("{0}%", currenthp / maxHp * 100);
    }
}