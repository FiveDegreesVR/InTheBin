using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSFXController : MonoBehaviour
{
    private AudioSource playerAudioSource;
    public AudioClip buttonSFX;
    
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerAudioSource = GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
        var buttonList = FindObjectsOfType<Button>(true);
        foreach (var button in buttonList)
        {
            if (!button.CompareTag("GameControlButton"))
            {
                button.onClick.AddListener(PlaySound);
            }
        }
    }

    private void PlaySound()
    {
        playerAudioSource.PlayOneShot(buttonSFX);
    }
}
