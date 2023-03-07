using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public float difficulty;

    public int spriteColor;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
