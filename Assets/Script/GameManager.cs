using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
     [SerializeField] private Transform[] spawnPoints;
     [SerializeField] private int waveCount;
     [SerializeField] private GameObject enemyPrefab;
     [SerializeField] private int enemyCountSpawn;
     [SerializeField] public int enemyIngame;
     [SerializeField] public bool playAlive = true;
     [SerializeField] public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCount == 0 && enemyCountSpawn < 4)
        {
            StartCoroutine(spawnEnemies());
            if (enemyCountSpawn >= 4 )
            {
                StopCoroutine(spawnEnemies());
                if (enemyIngame == 0)
                {
                    waveCount++;
                }
            }
        }

        if (waveCount > 0)
        {
            StartCoroutine(spawnEnemies());
            if (enemyCountSpawn >= 20)
            {
                StopCoroutine(spawnEnemies());
            }
        }
    }

    IEnumerator<WaitForSeconds> spawnEnemies()
    {
        Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        enemyCountSpawn++;

        if (waveCount == 0)
        {
            yield return new WaitForSeconds(0.5f);
        }
        else if (waveCount > 0)
        {
            yield return new WaitForSeconds(1f);
        }
    }
}
