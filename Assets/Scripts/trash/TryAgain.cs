//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine;
//using System.IO;
//using Newtonsoft.Json.Linq; //Para poder usar Json.net y estructuras de datos
//using System.Security.Cryptography;


//public class TryAgain : MonoBehaviour
//{
//    public string path;
//    public string mobilepath;
//    public GameManager gameManager;
//    public void SaveJson()
//    {
//        path = Application.dataPath;
//        mobilepath = Application.persistentDataPath;
//        GameData gameData = new GameData(gameManager.puntos, gameManager.playerTransform.position);
//    }

//    public void LoadJson()
//    {
//        string savePath = path + "/save.json";

//        if (File.Exists(savePath))
//        {
//            string json = File.ReadAllText(savePath);

//#if UNITY_ENGINE
		
// path = Application.dataPath;

//#endif

//#if UNITY_ANDROID

//    mobilepath = Application.persistentDataPath;

//#endif
//            GameData gameData = JsonUtility.FromJson<GameData>(json);

//            gameManager.puntos = gameData.puntos;
//            gameManager.playerTransform.position = gameData.playerPosition;

//            Debug.Log("Игра загружена.");
//        }
//        else
//        {
//            Debug.Log("Файл сохранения не найден.");
//        }
//    }
//}
