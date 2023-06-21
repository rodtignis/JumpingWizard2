using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;


public class HellManager : MonoBehaviour
{
    private Transform playerTransform;
    public int puntos;

    public Text nombreTXT;

    public string saveFileName = "save.json";
    private string saveFilePath;
    private JSONSaveLoad saveLoadScript;

    public Button ContinueButtonClicked;


    private void Start()
    {

        playerTransform = GameObject.FindWithTag("Player").transform;
        saveLoadScript = GetComponent<JSONSaveLoad>();

        ContinueButtonClicked.onClick.AddListener(LoadGameData);

    }

    public void SaveGameData()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
            Vector3 playerPosition = playerTransform.position;

            Debug.Log("Saving player position: " + puntos);
            Debug.Log("Saving player score: " + playerPosition);

            GameData gameData = new GameData(puntos, playerPosition);
            string jsonData = JsonUtility.ToJson(gameData);
            File.WriteAllText(saveFilePath, jsonData);
        }
        else
        {
            Debug.LogWarning("Player object with tag 'Player' not found. Unable to save game data.");
        }
    }

    private void LoadGameData()
    {
        GameData gameData = saveLoadScript.LoadData();
        if (gameData != null)
        {
            puntos = gameData.puntos;
            nombreTXT.text = puntos.ToString();
        }
    }
}


[System.Serializable]
public class GameData
{
    public int puntos;

    public GameData(int puntos)
    {
        this.puntos = puntos;
    }

    public GameData(int puntos, Vector3 playerPosition) : this(puntos)
    {
        PlayerPosition = playerPosition;
    }

    public Vector3 PlayerPosition { get; }
}

