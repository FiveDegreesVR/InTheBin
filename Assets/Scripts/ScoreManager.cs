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
    private static int pointsScore = 0;
    private static int lifeScore = 5;
    private static bool setPoints = false;
    private static bool setLifes = false;

    public void Start()
    {
        scoreGUI.text = scoreText + pointsScore;
        lifesGUI.text = lifeText + lifeScore;
    }
    
    public void AddPoints(int points) 
    {
        pointsScore += points;
        setPoints = true;
    }
    
    public void RemoveLives(int lifes) 
    {
        lifeScore -= lifes;
        setLifes = true;
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
