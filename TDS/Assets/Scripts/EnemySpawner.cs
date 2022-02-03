using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius = 7, time = 1.5f;
    public GameObject[] enemies;
    

    public void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    
    IEnumerator SpawnAnEnemy()
    {
        while(true)
        {
            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnAnEnemy());
        }
    }
}