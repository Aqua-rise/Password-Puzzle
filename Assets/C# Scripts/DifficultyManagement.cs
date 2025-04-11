using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManagement : MonoBehaviour
{
    private static DifficultyManagement instance;
    public string difficulty;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (difficulty == "easy")
        {
            FindEasyDifficultyHintObject();
        }
        else if (difficulty == "medium")
        {
            FindMediumDifficultyHintObject();
        }
    }

    private void FindEasyDifficultyHintObject()
    {
        GameObject easyModeTarget = GameObject.Find("(Easy Mode Exclusive) Puzzle Slot S1 Answer");
        GameObject easyModeTargetPosition = GameObject.Find("Easy Mode Target Position");
        if (easyModeTarget != null && easyModeTargetPosition != null)
        {
            Debug.Log("Found: " + easyModeTarget.name);
            easyModeTarget.transform.position = easyModeTargetPosition.transform.position;
            
        }
        else
        {
            //Debug.LogWarning("Target object not found!");
        }
    }
    
    private void FindMediumDifficultyHintObject()
    {
        GameObject mediumModeTarget = GameObject.Find("(Medium Mode) Guaranteed Text");
        GameObject mediumModeTargetPosition = GameObject.Find("Medium Mode Target Position");
        if (mediumModeTarget != null && mediumModeTargetPosition != null)
        {
            Debug.Log("Found: " + mediumModeTarget.name);
            mediumModeTarget.transform.localPosition = mediumModeTargetPosition.transform.localPosition;
        }
        else
        {
            //Debug.LogWarning("Target object not found!");
        }
    }

    public void SetDifficulty(string difficulty)
    {
        this.difficulty = difficulty;
    }

}
