using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Stage;

    public Text scoreText;
    public Text timeText;

    static public float time;
    static bool stage;

    static public int stageIndex = 0;
    void Start()
    {
        stageIndex = 0;
        time = 600;
    }

    void Update()
    {
        time -= Time.deltaTime;
        scoreText.text = string.Format("{0:n0}", Player.score);
        timeText.text = string.Format("{0} : {1}", (int)time / 60, (int)time % 60);
        if (stage && SpawnManager.curSpawnDelay < 0)
        {
            Stage.SetActive(true);
        }
        else
        {
            Stage.SetActive(false);
        }
    }

    static public void StageClear()
    {
        if(stageIndex == 2)
        {
            SceneManager.LoadScene("Finish");
        }
        else
        {
            stage = true;
            stageIndex++;
            SpawnManager.curSpawnDelay = -3;
            SpawnManager.isBossSpawn = false;
        }
    }

    static public void GameOver()
    {
        SceneManager.LoadScene("Finish");
    }
}
