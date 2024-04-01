using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ControlScheme
{
    Tap, Swipe, Tilt
}
public enum Difficulty
{
    Easy, Medium
}


public class PersistentDataObject : MonoBehaviour
{
    public static PersistentDataObject Instance { get; private set; }

    public ControlScheme activeControlScheme = ControlScheme.Tap;
    public Difficulty activeDifficulty = Difficulty.Easy;
    
    public void SetHighScore(int value)
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + ":HighScore", value);
    }
    
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + ":HighScore", 0);
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}

