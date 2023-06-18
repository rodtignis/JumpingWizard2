using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneretor : MonoBehaviour
{
	public GameObject platformPrefab;
	public GameObject platformMovingPrefab;

	public GameObject[] platforms;



	public int numberOfPlatforms = 2000;
	public float levelWidth = 3f;
	public float minY = .2f;
	public float maxY = 1.5f;

	void Start()
	{

		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++)
		{
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			int aleatorio = Random.Range(0,2); 
			Instantiate(platforms[aleatorio], spawnPosition, Quaternion.identity);
		}


	
	}
}
