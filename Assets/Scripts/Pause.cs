using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public Button pauseButton;
    private bool isPaused = false;
    public GameObject pauseMenu;
    public Image screenOverlay;




    private void Start()
    {
        pauseButton.onClick.AddListener(TogglePause);
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
        Time.timeScale = 0f;
        isPaused = true;


        pauseMenu.SetActive(true);
        screenOverlay.gameObject.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;


        pauseMenu.SetActive(false);
        screenOverlay.gameObject.SetActive(false);

    }






}
