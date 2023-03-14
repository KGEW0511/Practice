using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public Player player;
    public Text score;
    public Text stage;
    public Text time;

    void OnEnable()
    {
        score.text = string.Format("Score : {0}¡°", Player.score);
        stage.text = string.Format("Stage : {0}", GameManager.stageIndex);
        time.text = string.Format("Time : {0}√ ", 600 - (int)GameManager.time);
    }
}
