//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine;
//using System.IO;
//using Newtonsoft.Json.Linq; //Para poder usar Json.net y estructuras de datos
//using System.Security.Cryptography;


//public class HellManager : MonoBehaviour
//{

//    private Transform playerTransform;
//    //public int puntos;
//    public string saveFileName = "save.json";

//    private string saveFilePath;
//    private JSONSaveLoad saveLoadScript;
//    public string playerSceneName = "SampleScene";
//    public string playerObjectName = "wiz";

//    public GameManager referenc;

//    private void Awake()
//    {
//        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
//    }


//    private void Start()
//    {
//        saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName);
//        saveLoadScript = GetComponent<JSONSaveLoad>();

//        if (saveLoadScript != null)
//        {
//            Debug.Log("JSONSaveLoad component found.");
//        }
//        else
//        {
//            Debug.LogError("JSONSaveLoad component is missing.");
//        }
//    }

//    public void SaveGameData()
//    {
//        {
//            GameObject playerObject = GameObject.FindWithTag("Player");
//            if (playerObject != null)
//            {
//                Transform playerTransform = playerObject.transform;
//                Vector3 playerPosition = playerTransform.position;

//                Debug.Log("Saving player position: " + playerPosition);
//                Debug.Log("Saving player score: " + referenc.puntos);

//                GameData gameData = new GameData(referenc.puntos, playerPosition);
//                string jsonData = JsonUtility.ToJson(gameData);
//                File.WriteAllText(saveFilePath, jsonData);
//            }
//            else
//            {
//                Debug.LogWarning("Player object with tag 'Player' not found. Unable to save game data.");
//            }
//        }
//    }

//}

