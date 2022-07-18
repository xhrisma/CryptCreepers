﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]GameObject checkpointPrefab;
    [SerializeField]int checkpointSpawnDelay = 10;
    [SerializeField]float spawnRadius = 10;
    [SerializeField]GameObject[] powerUpPrefab;
    [SerializeField]int powerUpSpawnDelay = 12;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnCheckRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkpointSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle *spawnRadius;
            Instantiate(checkpointPrefab, randomPosition, Quaternion.identity);
        }
    }
    IEnumerator SpawnPowerUpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            int random = Random.Range(0, powerUpPrefab.Length);
            Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);

        }
    }
}
