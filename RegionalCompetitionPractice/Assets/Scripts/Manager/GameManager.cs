using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    public Text timeText;

    public float time;
    
    public int stageIndex;
    void Start()
    {
        time = 600;
    }

    void Update()
    {
         time -= Time.deltaTime;;
         scoreText.text = string.Format("{0:n0}", Player.score);
         timeText.text = string.Format("{0} : {1}", (int)time / 60, (int)time % 60);
    }
}
