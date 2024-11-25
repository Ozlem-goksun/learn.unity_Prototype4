using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNum);
        Instantiate(powerupPrefab, RandomSpawnPosition(), transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPosition(), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0 )
        {
            waveNum++;
            SpawnEnemyWave(waveNum);
            Instantiate(powerupPrefab, RandomSpawnPosition(), transform.rotation);

        }
    }

    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

}
