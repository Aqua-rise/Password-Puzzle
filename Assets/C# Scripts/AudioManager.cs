using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private int musicTrack;
    private float musicVolume;
    private bool hasBeenChanged;

    public GameObject UnsavedChangesText;
    public GameObject SuccessfulSaveText;
    
    public Slider volumeSlider;
    public List<AudioSource> musicList = new List<AudioSource>();
    public GameObject changeMusicButton1;
    public GameObject changeMusicButton2;
    
    private void Start()
    {
        // Load Player Data
        LoadPlayerData();
        //hasBeenChanged = false;

    }

    private void Update()
    {
        CheckForSaveDataChanges();
    }

    public void SetVolume(float sliderValue)
    {
        // Convert the slider value (0-100) to a volume value (0-1)
        foreach (AudioSource audioSource in musicList)
        {
            audioSource.volume = sliderValue / 100f;
        }
        ChangesHaveBeenMade();

    }

    public void SavePlayerSettings()
    {
        PlayerPrefs.SetInt("MusicTrack", musicTrack); // Save an integer value
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value); // Save a float value
        Debug.Log($"Volume Slider - {volumeSlider.value}");

        PlayerPrefs.Save(); // Ensures data is written to disk immediately
        SuccessfulSaveText.SetActive(true);
        hasBeenChanged = false;
        
        Debug.Log($"Saved Data: Music Track int - {musicTrack}, Volume Level - {musicVolume}");

    }

    public void CheckForSaveDataChanges()
    {
        // If current data is edited, toggle hasBeenChanged to true
        //else return false

        if (hasBeenChanged)
        {

            if (UnsavedChangesText.activeSelf == false)
            {
                UnsavedChangesText.SetActive(true);
            }
        }
        else
        {
            if (UnsavedChangesText.activeSelf)
            {
                UnsavedChangesText.SetActive(false);
            }
        }
    }

    public void ChangesHaveBeenMade()
    {
        if (hasBeenChanged == false && !Mathf.Approximately((volumeSlider.value), PlayerPrefs.GetFloat("MusicVolume")))
        {
            hasBeenChanged = true;
        }
        SuccessfulSaveText.SetActive(false);
    }

    void LoadPlayerData()
    {
        musicTrack = PlayerPrefs.GetInt("MusicTrack", 0); // Default to 0 if not found
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 50f); // Default to 100 if not found
        volumeSlider.value = musicVolume;
        SetVolume(musicVolume);
        enableMusicTrackButton();
        StartAudio();
        //Debug.Log($"Loaded Data: Music Track int - {musicTrack}, Volume Level - {musicVolume}");
    }

    public void StartAudio()
    {
            //Stop all music
            foreach (var source in musicList)
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
            }
            // Play the current saved track
            musicList[musicTrack].Play();
    }

    public void SetMusicTrack(int trackId)
    {
        PlayerPrefs.SetInt("MusicTrack", trackId);
        musicTrack = trackId;
        PlayerPrefs.Save();
        StartAudio();
        hasBeenChanged = true;
        SuccessfulSaveText.SetActive(false);
        //too lazy to fix method if implementation/ Just edit the variable lule
        //ChangesHaveBeenMade();
    }

    //need a method that doesn't save the track that it plays
    public void playUnsavedMusicTrack(int trackId)
    {
        musicTrack = trackId;
        StartAudio();
    }

    public void ReturnToSavedMusicTrack()
    {
        //Stop all music
        foreach (var source in musicList)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }
        //Overrite the local variable track ID with the saved track ID
        musicTrack = PlayerPrefs.GetInt("MusicTrack", 0);
        // Play the current saved track
        musicList[musicTrack].Play();
    }

    //Temp method
    private void enableMusicTrackButton()
    {
        if (musicTrack == 0)
        {
            changeMusicButton1.SetActive(true);
        }
        else
        {
            changeMusicButton2.SetActive(true);
        }
    }

    public void HideSuccessfulSaveText()
    {
        SuccessfulSaveText.SetActive(false);
    }

    public void ResetPlayerData()
    {
        PlayerPrefs.DeleteAll(); // Removes all saved preferences
        Debug.Log("All Player Data Reset!");
    }
}
