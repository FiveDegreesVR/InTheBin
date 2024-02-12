using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private PersistentDataObject _persistentDataObject;
    public TextMeshProUGUI controlSchemeText;
    public AudioMixer masterMixer;
    public Slider volumeSlider;

    private void Start()
    {
        _persistentDataObject = GameObject.FindWithTag("Persistent").GetComponent<PersistentDataObject>();
        controlSchemeText.text = _persistentDataObject.activeControlScheme.ToString();
        
        // set audio slider
        float value;
        bool result =  masterMixer.GetFloat("Volume", out value);
        if(result)
        {
            volumeSlider.value = value;
        }else{
            volumeSlider.value = 0;
        }
    }

    public void SetDifficulty(int difficultyIndex)
    {
        _persistentDataObject.activeDifficulty = (Difficulty)difficultyIndex;
    }
    
    public void SetControlScheme(int controlSchemeIndex)
    {
        ControlScheme controlScheme = (ControlScheme) controlSchemeIndex;
        controlSchemeText.text = controlScheme.ToString();
        _persistentDataObject.activeControlScheme = controlScheme;
    }

    public void ChangeVolume()
    {
        masterMixer.SetFloat("Volume", volumeSlider.value);
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
