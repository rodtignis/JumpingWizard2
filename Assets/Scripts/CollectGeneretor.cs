using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGeneretor : MonoBehaviour
{
	public GameObject collectiblePrefab;

	public int numberOfCollectibles = 50;
	public float levelWidth = 3f;
	public float levelHeight = 5f;

	public float minY = .2f;
	public float maxY = 1.5f;
	public float collectibleSpawnChance = 0.05f;

	void Start()
	{
		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfCollectibles; i++)
		{
			float spawnChance = Random.Range(0f, 1f);
			if (spawnChance <= collectibleSpawnChance)
			{
				spawnPosition.y += Random.Range(minY, maxY);
				spawnPosition.x = Random.Range(-levelWidth, levelWidth);
				GameObject collectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
				collectible.tag = "Collectible"; // Присваиваем тег "Collectible"
			}
		}

		// Активируем предметы
		GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
		foreach (GameObject collectible in collectibles)
		{
			collectible.SetActive(true);
		}
	}


}
