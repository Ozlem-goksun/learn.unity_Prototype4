using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, RandomSpawnPosition(), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

}
