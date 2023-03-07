using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pain_Bar : MonoBehaviour
{
    public Player player;
    public Slider painBar;

    public Text painText;
    public float maxPain;
    public float currentPain;

    void Awake()
    {
        maxPain = player.fuel;
    }

    void Update()
    {
        currentPain = player.life;
        painBar.value = currentPain / maxPain;
        painText.text = string.Format("{0}%", currentPain / maxPain * 100);
    }
}
