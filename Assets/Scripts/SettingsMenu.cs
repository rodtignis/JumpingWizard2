using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingsMenu : MonoBehaviour
{

    public Button backButton;



    void Start()
    {
        backButton.onClick.AddListener(BackToMainMenu);


    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}