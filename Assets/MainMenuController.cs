using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private PersistentDataObject _persistentDataObject;
    public TextMeshProUGUI controlSchemeText;

    private void Start()
    {
        _persistentDataObject = GetComponent<PersistentDataObject>();
        controlSchemeText.text = _persistentDataObject.activeControlScheme.ToString();
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

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
