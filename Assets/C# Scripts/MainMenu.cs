using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void PlayGameEasy()
    {
        SceneManager.LoadScene("Easy 2.0");

    }
    public void PlayGameMedium()
    {
        SceneManager.LoadScene("Medium 2.0");
        
    }
    public void PlayGameHard()
    {
        SceneManager.LoadScene("Hard");

    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
