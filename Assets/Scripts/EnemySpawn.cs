﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]GameObject[] enemyPrefab;
    [Range(1,10)][SerializeField]float spawnRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/spawnRate);
            float random = Random.Range(0.0f, 1.0f);
            if (random < GameManager.Instance.difficulty*0.1f)
            {
                Instantiate(enemyPrefab[0]);
            }
            else
            {
                Instantiate(enemyPrefab[1]);
            }
        }
    }
}
