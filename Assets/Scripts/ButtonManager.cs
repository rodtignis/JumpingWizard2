using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Canvas Manager + buttons

public class ButtonManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Button settingsButton;
    public Button scoreGo;
    public Button Back;
    public Button exitMenu;
    public Button backToGame;

    public Canvas BM;
    public Canvas Settings;
    public Canvas Score;
    void Start()
    {
        startButton.onClick.AddListener(StartNewGame);
        settingsButton.onClick.AddListener(OpenSettingsMenu);
        exitButton.onClick.AddListener(ExitGame);
        scoreGo.onClick.AddListener(OpenScoreMenu);
        Back.onClick.AddListener(BackOnClick);
        exitMenu.onClick.AddListener(BackToMenu);
        backToGame.onClick.AddListener(BackToGame);


        BM.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
    }

    void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenSettingsMenu()
    {
        BM.gameObject.SetActive(false);
        Settings.gameObject.SetActive(true);
    }

    public void OpenScoreMenu()
    {
        BM.gameObject.SetActive(false);
        Score.gameObject.SetActive(true);

    }


    public void BackOnClick()
    {
        BM.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
    }


    public void BackToMenu()
    {
        BM.gameObject.SetActive(true);
        Score.gameObject.SetActive(false);
    }

    public void BackToGame()
    {
        SceneManager.LoadScene("SampleScene");
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
