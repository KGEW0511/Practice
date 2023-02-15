using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObjs;
    public Transform[] enemySpawnPoints;

    public GameObject[] cellObjs;
    public Transform[] cellSpawnPoints;

    public GameObject player;
    public Text scoreText;
    public GameObject gameOverSet;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public int CellSpawn;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();

            CellSpawn++;
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }

        if(CellSpawn >= 5)
        {
            SpawnCells();
            CellSpawn = 0;
        }

        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);

        if(playerLogic.life <= 0 || playerLogic.pain >= 100)
        {

        }
    }

    void SpawnCells()
    {
        int ranCell = Random.Range(0, 2);
        int ranPoint = Random.Range(0, 3);

        GameObject Cell = Instantiate(cellObjs[ranCell],
                                    cellSpawnPoints[ranPoint].position,
                                    cellSpawnPoints[ranPoint].rotation);

        Rigidbody2D rigid = Cell.GetComponent<Rigidbody2D>();
    }
    
    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 5);

        GameObject enemy = Instantiate(enemyObjs[ranEnemy],
                                    enemySpawnPoints[ranPoint].position,
                                    enemySpawnPoints[ranPoint].rotation);

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
    }
}
