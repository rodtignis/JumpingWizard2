using System.Collections;
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

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "save.json");
    }

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


    public void LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {

            if (File.Exists(saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName)))
            {
                string jsonData = File.ReadAllText(saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName));

                GameData gameData = JsonUtility.FromJson<GameData>(jsonData);

                Vector3 position = gameData.playerPosition;
                int puntos = gameData.puntos;

                GameData.Instance.playerPosition = position;
                GameData.Instance.puntos = puntos;

                Debug.Log("Game loaded! Score: " + puntos + ", Position: " + position);

                GameObject playerObject = GameObject.FindWithTag("Player");
                GameObject puntosObject = GameObject.FindWithTag("NombreText");

                if (playerObject != null)
                {
                    playerObject.transform.position = position;
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


        }         

        SceneManager.LoadSceneAsync("SampleScene");


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

//public class HellManage : MonoBehaviour
//{
//    private Transform playerTransform;
//    public int puntos;

//    public string gameSceneName = "Samplecene";
//    public string saveFileName = "save.json";

//    private string saveFilePath;

//    private void Awake()
//    {
//        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
//    }

//    private JSONSaveLoad saveLoadScript;
//    public string playerSceneName = "SampleScene";
//    public string playerObjectName = "wiz";



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
//        GameObject playerObject = GameObject.FindWithTag("Player");
//        if (playerObject != null)
//        {
//            Transform playerTransform = playerObject.transform;
//            Vector3 playerPosition = playerTransform.position;

//            Debug.Log("Saving player position: " + playerPosition);
//            Debug.Log("Saving player score: " + puntos);


//            saveLoadScript.SaveData(new GameData(puntos, playerPosition));
//        }
//        else
//        {
//            Debug.LogWarning("Player object with tag 'Player' not found. Unable to save game data.");
//        }
//    }

//}

//[System.Serializable]
//public class GameData
//{
//    public int puntos;
//    public Vector3 playerPosition;

//    public GameData(int puntos, Vector3 playerPosition)
//    {
//        this.puntos = 0;
//        this.playerPosition = playerPosition;
//    }
//}