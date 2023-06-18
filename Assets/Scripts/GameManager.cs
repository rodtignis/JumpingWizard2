using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librerías añadidas
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Transform playerTransform;
    public int puntos;

    public Text puntosTXT;
    public Text nombreTXT;
    public GameObject rankingGO;




    private void Start()
    {

        playerTransform = GameObject.FindWithTag("Player").transform;
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



}
