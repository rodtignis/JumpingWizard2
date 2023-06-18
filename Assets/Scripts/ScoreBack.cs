using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreBack : MonoBehaviour
{

    public Button backMenu;



    void Start()
    {
        backMenu.onClick.AddListener(BackToMainMenu);


    }


    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
