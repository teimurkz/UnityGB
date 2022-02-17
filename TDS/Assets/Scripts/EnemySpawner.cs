using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius = 7, time = 1.5f;
    public GameObject[] enemies;
    public int EnemyCounter;
    public float timer = 0;

    private void Update()
    {
        timer = timer + Time.deltaTime;
        if (EnemyCounter <= 0 && timer >= 5)
        {
            Vector2 spawnPos =   GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
            EnemyCounter++;
            timer = 0;

        }
    }
}