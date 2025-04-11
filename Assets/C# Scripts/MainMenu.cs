using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   DifficultyManagement difficultyManagement;
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        FindDifficultyManager();
    }

    void FindDifficultyManager()
    {
        //Find difficulty manager
        GameObject DifficultyManager = GameObject.Find("Difficulty Manager");

        if (difficultyManagement == null)
        {
            difficultyManagement = DifficultyManager.GetComponent<DifficultyManagement>();
        }
    }

    public void SetDifficulty(string difficulty)
    {
        try
        {
            difficultyManagement.SetDifficulty(difficulty);
        }
        catch
        {
            //Debug.Log("Could not find difficulty manager");
        }
    }

}
