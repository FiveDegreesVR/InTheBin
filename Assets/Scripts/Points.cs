using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI score;

    private static string scoreText = "Score: ";
    private static int pointsScore = 0;
    private static bool setPoints = false;

    public void Start()
    {
        score.text = scoreText + pointsScore;
    }
    public static void gotPoints(int points) 
    {
        pointsScore += points;
        setPoints = true;
    }

    public void Update()
    {
       if(setPoints)
        {
            setPoints = !setPoints;
            score.text = scoreText + pointsScore;
        }
    }
}
