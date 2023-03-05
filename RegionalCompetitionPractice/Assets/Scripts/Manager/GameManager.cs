using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource audioSource;

    public GameObject[] horEnemyObjs;
    public Transform[] horEnemySpawnPoints;

    public GameObject[] VerEnemyObjs;
    public Transform[] VerEnemySpawnPoints;

    public GameObject bossObjs;
    public Transform bossSpawnPoints;

    public GameObject player;
    public Text scoreText;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public bool isLeft;
    public bool isRight;
    public bool isBossSpawn;

    public int stage;
    public int bossSpawn;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
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
            SpawnVerEnemy();
            SpawnHorEnemy();

            maxSpawnDelay = 2f;
            curSpawnDelay = 0;
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
    
    void SpawnVerEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 5);

        GameObject enemy = Instantiate(VerEnemyObjs[ranEnemy],
                                    VerEnemySpawnPoints[ranPoint].position,
                                    VerEnemySpawnPoints[ranPoint].rotation);

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
    }

    void SpawnHorEnemy()
    {
        int ranPoint = Random.Range(0, 4);

        GameObject enemy;

        if(ranPoint < 2)
        {
            enemy = Instantiate(horEnemyObjs[0],
                                    horEnemySpawnPoints[ranPoint].position,
                                    horEnemySpawnPoints[ranPoint].rotation);
            
        }
        else
        {
            enemy = Instantiate(horEnemyObjs[1],
                                    horEnemySpawnPoints[ranPoint].position,
                                    horEnemySpawnPoints[ranPoint].rotation);
        }

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
    }
}
