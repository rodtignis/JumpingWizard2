using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deadscript : MonoBehaviour
{


    public Button restart;
    public Button showScore;
    public Button exitMenu;
    public Button exitGame;

    void Start()
    {
        restart.onClick.AddListener(ResetGame);
        exitMenu.onClick.AddListener(OpenMenu);
        exitGame.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

   
    
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }



}
