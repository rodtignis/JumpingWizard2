using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librerías añadidas
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private Transform playerTransform;
    public int puntos;

    public Text puntosTXT;
    public Text nombreTXT;
    public GameObject rankingGO;


    private JSONSaveLoad saveLoadScript;


    private void Start()
    {

        playerTransform = GameObject.FindWithTag("Player").transform;
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
        // Дополнительные действия по завершению игры, например, переключение на сцену главного меню
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueButtonClicked()
    {
        LoadGameData();
        ResumeGame();
        SceneManager.LoadScene("SampleScene");
    }

    public void SaveGameData()
    {
        Vector3 playerPosition = playerTransform.position;
        saveLoadScript.SaveData(new GameData(puntos, playerPosition));
    }

    private void LoadGameData()
    {
        GameData gameData = saveLoadScript.LoadData();
        if (gameData != null)
        {
            puntos = gameData.puntos;
            nombreTXT.text = puntos.ToString();
            playerTransform.position = gameData.playerPosition;

        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        // Дополнительные действия при продолжении игры
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

