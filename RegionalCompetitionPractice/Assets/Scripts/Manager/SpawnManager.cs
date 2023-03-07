using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject Asteroids;
    public GameObject[] bossObj;
    public GameObject[] EnemyObjs;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public float BossSpawnDelay;

    public bool isBossSpawn;

    void Awake()
    {
        isBossSpawn = false;
    }
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay && !isBossSpawn)
        {
            SpawnEnemy();
            SpawnAsteroids();

            maxSpawnDelay = 1.5f;
            curSpawnDelay = 0;
        }

        if (!isBossSpawn)
        {
            BossSpawnDelay += Time.deltaTime;
        }
        
        if (BossSpawnDelay > 180)
        {
            GameObject boss = Instantiate(bossObj[GameObject.FindObjectOfType<GameManager>().stageIndex], new Vector3(0, 7, -1), Quaternion.Euler(0, 0, 0));
            BossSpawnDelay = 0;
            isBossSpawn = true;
        }
    }

    void SpawnAsteroids()
    {
        float ranPoint = Random.Range(-5f, 5f);

        GameObject Asteroid = Instantiate(Asteroids, new Vector3(ranPoint, 5, -1), Quaternion.Euler(0, 0, 0));
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        float ranPoint = Random.Range(-5f, 5f);

        GameObject enemy = Instantiate(EnemyObjs[ranEnemy], new Vector3(ranPoint, 5, -1), Quaternion.Euler(0, 0, 0));
    }
}
