using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject InGameUI;
    public GameObject TapControlUI;
    public GameObject EndGameUI;
    public TextMeshProUGUI gameOverScoreText;
    private ScoreManager _scoreManager;
    private bool tapControlsInUse = false;

    private void Awake()
    {
        _scoreManager = GetComponent<ScoreManager>();
    }

    public void PauseGame()
    {
        if (TapControlUI.activeSelf)
        {
            tapControlsInUse = true;
            TapControlUI.SetActive(false);
        }
        Time.timeScale = 0f;
    }
    
    public void UnpauseGame()
    {
        if (tapControlsInUse)
        {
            tapControlsInUse = false;
            TapControlUI.SetActive(true);
        }
        Time.timeScale = 1f;
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        
        InGameUI.SetActive(false);
        if (TapControlUI.activeSelf)
        {
            TapControlUI.SetActive(false);
        }
        EndGameUI.SetActive(true);
        
        gameOverScoreText.text = _scoreManager.GetPoints().ToString();
    }
}
