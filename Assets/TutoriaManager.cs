using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutoriaManager : MonoBehaviour
{
    public Button pauseButton;
    private bool isPaused = false;
    public GameObject pauseMenu;
    public Image screenOverlay;
    private bool isMenuVisible = false;
    public Button resumeButton;






    private void Start()
    {
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(ResumeGame);

    }

    private void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 1f;
        isPaused = true;
        
        isMenuVisible = true;

        pauseMenu.SetActive(true);
        screenOverlay.gameObject.SetActive(true);
    }


    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;


        pauseMenu.SetActive(false);
        screenOverlay.gameObject.SetActive(false);
        isMenuVisible = false;

    }




}

