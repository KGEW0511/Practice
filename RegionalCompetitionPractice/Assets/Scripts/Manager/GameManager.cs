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

    public GameObject bossObjs;
    public Transform bossSpawnPoints;

    public GameObject player;
    public Text scoreText;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public bool isBossSpawn;

    public int stage;
    public int cellSpawn;
    public int bossSpawn;

    void Awake()
    {
        isBossSpawn = false;
    }
    void Update()
    {
        Spawn();

        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);

        if(playerLogic.life <= 0 || playerLogic.pain >= 100)
        {

        }
    }

    void Spawn()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay && !isBossSpawn)
        {
            SpawnEnemy();

            cellSpawn++;
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }
        else if (cellSpawn >= 5)
        {
            SpawnCells();
            cellSpawn = 0;
            bossSpawn++;
        }
        else if (bossSpawn >= 5 && !isBossSpawn)
        {
            GameObject boss = Instantiate(bossObjs,
                                    bossSpawnPoints.position,
                                    bossSpawnPoints.rotation);
            Rigidbody2D rigid = boss.GetComponent<Rigidbody2D>();
            isBossSpawn = true;
        }
    }

    void SpawnCells()
    {
        int ranCell = Random.Range(0, 2);
        int ranPoint = Random.Range(0, 5);

        GameObject cell = Instantiate(cellObjs[ranCell],
                                    cellSpawnPoints[ranPoint].position,
                                    cellSpawnPoints[ranPoint].rotation);

        Rigidbody2D rigid = cell.GetComponent<Rigidbody2D>();
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
