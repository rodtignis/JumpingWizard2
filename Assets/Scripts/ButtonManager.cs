using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Button settingsButton;
    public Button scoreGo;



    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(OpenSettingsMenu);
        exitButton.onClick.AddListener(ExitGame);
        scoreGo.onClick.AddListener(OpenScoreMenu);


    }

    void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void OpenScoreMenu()
    {
        SceneManager.LoadScene("Score");
    }

    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
