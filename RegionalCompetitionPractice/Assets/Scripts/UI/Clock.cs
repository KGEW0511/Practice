using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Clock : MonoBehaviour
{
    float Value;

    public GameManager gameManager;

    public Image LoadingBar;


    void Start()
    {
        Value = 600;
    }

    void Update()
    {
        LoadingBar.fillAmount = gameManager.time / Value;
    }
}
