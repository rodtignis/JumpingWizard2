﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librerías añadidas
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json.Linq; //Para poder usar Json.net y estructuras de datos
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public int puntos;

    public string gameSceneName = "SampleScene";
    public string saveFileName = "save.json";

    private string saveFilePath;

    public Text nombreTXT;
    public GameObject rankingGO;
    public Transform playerTransform;


    //private JSONSaveLoad saveLoadScript;
    public string playerSceneName = "SampleScene";
    public string playerObjectName = "wiz";



    private void Start()
    {

        saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName);

        //saveLoadScript = GetComponent<JSONSaveLoad>();

        if (saveFilePath != null)
        {
            Debug.Log("JSONSaveLoad component found.");
        }
        else
        {
            Debug.LogError("JSONSaveLoad component is missing.");
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void GuardarPuntosDB()
    {
        rankingGO.GetComponent<RankingManager>().InsertarPuntos("Wizard", puntos);
    }

    public void ExitButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }



    public void SaveGameData()
    {
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                Transform playerTransform = playerObject.transform;
                Vector3 playerPosition = playerTransform.position;

                Debug.Log("Saving player position: " + playerPosition);
                Debug.Log("Saving player score: " + puntos);

                PlayerPrefs.SetInt("puntos", puntos);

                GameData gameData = new GameData(puntos, playerPosition);
                string jsonData = JsonUtility.ToJson(gameData);
                File.WriteAllText(saveFilePath, jsonData);
            }
            else
            {
                Debug.LogWarning("Player object with tag 'Player' not found. Unable to save game data.");
            }
        }
    }


    public void LoadGameButton()
    {
        SceneManager.LoadScene("SampleScene");
        LoadGameData();
    }


    public void LoadGameData()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName);
        if (File.Exists(saveFilePath))
            {
            string jsonData = File.ReadAllText(saveFilePath);

            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);

                Vector3 playerPosition = gameData.playerPosition;
                int puntos = gameData.puntos;

                GameData.Instance.playerPosition = playerPosition;
                GameData.Instance.puntos = puntos;

                Debug.Log("Game loaded! Score: " + puntos + ", Position: " + playerPosition);

                GameObject playerObject = GameObject.FindWithTag("Player");
                GameObject puntosObject = GameObject.FindWithTag("NombreText");

                if (playerObject != null)
                {
                    playerObject.transform.position = playerPosition;
                }
                else
                {
                    Debug.LogWarning("Player object with tag 'Player' not found. Unable to restore game data.");
                }

                if (puntosObject != null)
                {
                    puntosObject.GetComponent<Text>().text = puntos.ToString();
                    nombreTXT.text = PlayerPrefs.GetInt("puntos").ToString();
                }
                else
                {
                    Debug.LogWarning("Puntos object with tag 'NombreText' not found. Unable to restore game data.");
                }
            }
            else
            {
                Debug.Log("No save file found!");
            }


             

        ResumeGame();

    }



    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

}




[System.Serializable]
public class GameData
{

    public int puntos;
    public Vector3 playerPosition;

    public GameData(int puntos, Vector3 playerPosition)
    {
        this.puntos = puntos;
        this.playerPosition = playerPosition;
    }


    private static GameData instance;

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }
            return instance;
        }
    }

    private GameData() { }
}