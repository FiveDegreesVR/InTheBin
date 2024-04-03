using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreGUI;
    public TextMeshProUGUI lifesGUI;

    private static string scoreText = "Score: ";
    private static string lifeText = "Lives: ";
    private static int pointsScore;
    private static int lifeScore;
    private static bool setPoints = false;
    private static bool setLifes = false;

    private UIManager _uiManager;

    private AudioSource clipAudioSource;
    public AudioClip scoreClip;
    public AudioClip loseClip;

    public int multiplier = 1;

    private void Awake()
    {
        clipAudioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        pointsScore = 0;
        lifeScore = 5;
        
        scoreGUI.text = scoreText + pointsScore;
        lifesGUI.text = lifeText + lifeScore;
        _uiManager = GetComponent<UIManager>();
    }
    
    public void AddPoints(int points) 
    {
        pointsScore += points*multiplier;
        setPoints = true;
        clipAudioSource.PlayOneShot(scoreClip);
    }
    
    public int GetPoints()
    {
        return pointsScore;
    }

    public void AddLives(int lifes)
    {
        lifeScore += lifes;
        setLifes = true;
    }
    
    public void RemoveLives(int lifes) 
    {
        lifeScore -= lifes;
        setLifes = true;
        clipAudioSource.PlayOneShot(loseClip, 0.8f);

        if (lifeScore<=0)
        {
            _uiManager.EndGame();
        }
    }

    public void Update()
    {
       if(setPoints)
       {
           setPoints = !setPoints;
           scoreGUI.text = scoreText + pointsScore;
       }
       if(setLifes)
       {
           setLifes = !setLifes;
           lifesGUI.text = lifeText + lifeScore;
       }
    }
}
