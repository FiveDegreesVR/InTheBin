using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    public enum Powerup
    {
        None, AddLife, Magnet, TwoXMultiplier
    }

    private Powerup storedPowerup = Powerup.None;
    public Powerup activePowerup = Powerup.None;
    // private bool currentItemActive = false;

    public Image storedPowerupUIButton;
    public Sprite noneUI;
    public Sprite addLifeUI;
    public Sprite magnetUI;
    public Sprite multiplierUI;

    public TMP_Text PowerupText;

    public GameObject twoXScoreContextUI;
    public GameObject magnetContextUI;
    
    // public GameObject trashCan;
    
    // private PhysicThrowScript _throwableSpawner;
    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = GetComponent<ScoreManager>();
    }

    public void SetStoredPowerup(Powerup newPowerup)
    {
        storedPowerup = newPowerup;
        storedPowerupUIButton.sprite = noneUI;
        
        switch (storedPowerup)
        {
            case Powerup.AddLife:
                storedPowerupUIButton.sprite = addLifeUI;
                PowerupText.text = "Powerup:\n+1Life";
                break;
            case Powerup.Magnet:
                storedPowerupUIButton.sprite = magnetUI;
                PowerupText.text = "Powerup:\nMagnet";
                break;
            case Powerup.TwoXMultiplier:
                storedPowerupUIButton.sprite = multiplierUI;
                PowerupText.text = "Powerup:\n2xScore";
                break;
            default:
                storedPowerupUIButton.sprite = noneUI;
                PowerupText.text = "Powerup:\nNone";
                break;
        }
    }

    public void UseStoredPowerup()
    {
        activePowerup = storedPowerup;
        CancelInvoke(nameof(PowerupExpired));
        storedPowerupUIButton.sprite = noneUI;
        PowerupText.text = "Powerup:\nNone";
        
        switch (storedPowerup)
        {
            case Powerup.AddLife:
                //add life 
                _scoreManager.AddLives(1);
                break;
            case Powerup.Magnet:
                // currentItemActive = true;
                magnetContextUI.SetActive(true);
                Invoke(nameof(PowerupExpired), 5.0f);
                break;
            case Powerup.TwoXMultiplier:
                // currentItemActive = true;
                twoXScoreContextUI.SetActive(true);
                Invoke(nameof(PowerupExpired), 10.0f);
                //activate multiplier
                _scoreManager.multiplier = 2;
                break;
            default:
                break;
        }
    }
    
    public void PowerupExpired()
    {
        //set multiplier in score script
        if (activePowerup == Powerup.TwoXMultiplier)
        {
            twoXScoreContextUI.SetActive(false);
            _scoreManager.multiplier = 1;
        }
        
        magnetContextUI.SetActive(false);
        activePowerup = Powerup.None;
    }

}
