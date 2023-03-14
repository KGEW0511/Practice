using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Clock : MonoBehaviour
{
    float Value;

    public Image LoadingBar;


    void Start()
    {
        Value = 600;
    }

    void Update()
    {
        LoadingBar.fillAmount = GameManager.time / Value;
    }
}
