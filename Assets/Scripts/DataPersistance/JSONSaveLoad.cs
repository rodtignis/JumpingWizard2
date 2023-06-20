using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //Usar StreamWriter y StreamReader


public class JSONSaveLoad : MonoBehaviour

{
    private string saveFilePath;

    private void Awake()
    {
        // Определите путь к файлу сохранения
        saveFilePath = Path.Combine(Application.persistentDataPath, "save.json");
    }

    public void SaveData(GameData gameData)
    {
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, jsonData);
        Debug.Log("Game data saved.");
    }

    public GameData LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            string jsonData = File.ReadAllText(saveFilePath);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);
            Debug.Log("Game data loaded.");
            return gameData;
        }
        else
        {
            Debug.Log("No save file found.");
            return null;
        }
    }
}
