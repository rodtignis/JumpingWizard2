using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librerías añadidas
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;



public class GameManager : MonoBehaviour
{
    private Transform playerTransform;
    public int puntos;

    public Text nombreTXT;
    public GameObject rankingGO;

    private JSONSaveLoad saveLoadScript;
    public string playerSceneName = "SimpleScene";
    public string playerObjectName = "wiz";

    private void Start()
    {
        playerTransform = GetPlayerTransformFromScene(playerSceneName, playerObjectName);
        saveLoadScript = GetComponent<JSONSaveLoad>();

        if (saveLoadScript != null)
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

    public void ContinueButtonClicked()
    {
        LoadGameData();
        SceneManager.LoadScene("SampleScene");
        ResumeGame();
    }

    public void SaveGameData()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
            Vector3 playerPosition = playerTransform.position;
            saveLoadScript.SaveData(new GameData(puntos, playerPosition));
        }
        else
        {
            Debug.LogWarning("Player object with tag 'Player' not found. Unable to save game data.");
        }
    }

    private GameData LoadGameData()
    {
        GameData gameData = saveLoadScript.LoadData();
        if (gameData != null)
        {
            puntos = gameData.puntos;

            if (PlayerPrefs.HasKey("NombreValue"))
            {
                string nombreValue = PlayerPrefs.GetString("NombreValue");
                GameObject[] nombreTextObjects = GameObject.FindGameObjectsWithTag("NombreText");
                if (nombreTextObjects.Length > 0)
                {
                    Text nombreText = nombreTextObjects[0].GetComponent<Text>();
                    nombreText.text = nombreValue;
                }

                return gameData; // Возвращаем объект GameData
            }

            // Загрузка сцены с игроком, если она не загружена
            if (!SceneManager.GetSceneByName(playerSceneName).isLoaded)
            {
                SceneManager.LoadScene(playerSceneName, LoadSceneMode.Additive);
            }

            // Поиск игрового объекта игрока в нужной сцене
            Scene playerScene = SceneManager.GetSceneByName(playerSceneName);
            if (playerScene.IsValid())
            {
                GameObject[] players = playerScene.GetRootGameObjects();
                foreach (GameObject player in players)
                {
                    if (player.CompareTag("Player"))
                    {
                        playerTransform = player.transform;
                        playerTransform.position = gameData.playerPosition;
                        break;
                    }
                }

                if (playerTransform == null)
                {
                    Debug.LogWarning("Player object not found in the scene. Unable to set player position from game data.");
                }
            }
            else
            {
                Debug.LogWarning("Player scene is not valid. Unable to load player object.");
            }

            return gameData;
        }
        else
        {
            Debug.LogWarning("No saved game data found.");
            return null; // Возвращаем null, если данные сохранения отсутствуют
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private Transform GetPlayerTransformFromScene(string sceneName, string objectName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (scene.IsValid())
        {
            GameObject[] rootObjects = scene.GetRootGameObjects();
            foreach (GameObject rootObject in rootObjects)
            {
                Transform playerTransform = rootObject.transform.Find(objectName);
                if (playerTransform != null)
                    return playerTransform;
            }
        }
        return null;
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
}