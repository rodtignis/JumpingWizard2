using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] enemies;
    public int numberOfEnemies = 100;
    public float levelWidth = 3f;
    public float levelHeight = 5f;

    public float minY = .2f;
    public float maxY = 1.5f;
    public float enemySpawnChance = 0.1f;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfEnemies; i++)
        {
            float spawnChance = Random.Range(0f, 1f);
            if (spawnChance <= enemySpawnChance)
            {
                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                int aleatorio = Random.Range(0, 2);
                GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemyObject.tag = "Enemy"; // ѕрисваиваем тег "Enemy" дл€ каждого созданного врага 

            }
        }

        GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemyObject in activeEnemies)
        {
            enemyObject.SetActive(true);
        }
    }


}
