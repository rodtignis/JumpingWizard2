using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 2f;

    private float timeToSpawn = 0f;

    private void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnEnemy();
            timeToSpawn = Time.time + spawnDelay;
        }
    }

    private void SpawnEnemy()
    {
        float xPos = Random.Range(-4f, 4f);
        Vector2 spawnPos = new Vector2(xPos, transform.position.y);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
