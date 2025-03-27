using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsMenu : MonoBehaviour
{
    public GameObject resultsMenu;
    public static bool freezeGame;
    public static bool onceBool = true;

    void Start()
    {
        onceBool = true;
        freezeGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (resultsMenu.activeSelf)
        {
            freezeGame = true;
        }

        if (onceBool)
        {
            if (freezeGame)
            {
                Time.timeScale = 0f;
                onceBool = false;

            }
        }

    }


    public void ReloadEasy2Mode()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Easy 2.0");
    }
    public void ReloadMedium2Mode()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Medium 2.0");
    }
    public void ReloadHardMode()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Hard");
    }
    


    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

}
