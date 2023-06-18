using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update

    public Button exitMenu;
    public Button backToGame;
    void Start()
    {
        exitMenu.onClick.AddListener(OpenMenu);
        backToGame.onClick.AddListener(OpenGame);

    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
