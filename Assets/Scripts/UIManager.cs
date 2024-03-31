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

    public GameObject movementController;
    private TapControls _tapControls;
    private SwipeControls _swipeControls;
    private TiltControl _tiltControl;

    [SerializeField] HighscoreHandler highscoreHandler;

    private PersistentDataObject _persistentDataObject;

    private void Awake()
    {
        _scoreManager = GetComponent<ScoreManager>();

        _tapControls = movementController.GetComponent<TapControls>();
        _swipeControls = movementController.GetComponent<SwipeControls>();
        _tiltControl = movementController.GetComponent<TiltControl>();

        _tapControls.enabled = false;
        _swipeControls.enabled = false;
        _tiltControl.enabled = false;
    }

    private void Start()
    {
        _persistentDataObject = GameObject.FindWithTag("Persistent").GetComponent<PersistentDataObject>();

        switch (_persistentDataObject.activeControlScheme)
        {
            case ControlScheme.Tap:
                TapControlUI.SetActive(true);
                _tapControls.enabled = true;
                break;
            case ControlScheme.Swipe:
                _swipeControls.enabled = true;
                break;
            case ControlScheme.Tilt:
                _tiltControl.enabled = true;
                break;
        }
        
        Time.timeScale = 1f;
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
        highscoreHandler.AddHighscoreIfPossible(new HighscoreElement(_scoreManager.GetPoints()));
    }
}
