using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreGUI;
    public TextMeshProUGUI lifesGUI;

    private static string scoreText = "Score: ";
    private static string lifeText = "Lives: ";
    public static int pointsScore;
    private static int lifeScore;
    private static bool setPoints = false;
    private static bool setLifes = false;

    private UIManager _uiManager;

    private AudioSource clipAudioSource;
    public AudioClip scoreClip;
    public AudioClip loseClip;

    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;
    List<GameObject> uiElements = new List<GameObject>();

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
        pointsScore += points;
        setPoints = true;
        clipAudioSource.PlayOneShot(scoreClip);
    }
    
    public int GetPoints()
    {
        return pointsScore;
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
    private void UpdateHSUI(List<HighscoreElement> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            HighscoreElement el = list[i];

            if (el != null && el.points > 0)
            {
                if (i >= uiElements.Count)
                {
                    // instantiate new entry
                    var inst = Instantiate(highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);

                    uiElements.Add(inst);
                }

                // write or overwrite name & points
                var texts = uiElements[i].GetComponentsInChildren<Text>();
                texts[1].text = el.points.ToString();
            }
        }
    }
}
