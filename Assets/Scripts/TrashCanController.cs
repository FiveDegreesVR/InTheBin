using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanController : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private PowerUpController _powerUpController;
    
    private void Awake()
    {
        _scoreManager = GameObject.FindWithTag("GameController").GetComponent<ScoreManager>();
        _powerUpController = _scoreManager.gameObject.GetComponent<PowerUpController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable"))
        {
            _scoreManager.AddPoints(2);
            other.gameObject.SetActive(false);
        }
        
        if (other.CompareTag("PowerupAddLife"))
        {
            _powerUpController.SetStoredPowerup(PowerUpController.Powerup.AddLife);
            other.gameObject.SetActive(false);
        }
        
        if (other.CompareTag("PowerupMagnet"))
        {
            _powerUpController.SetStoredPowerup(PowerUpController.Powerup.Magnet);
            other.gameObject.SetActive(false);
        }
        
        if (other.CompareTag("PowerupMultiplier"))
        {
            _powerUpController.SetStoredPowerup(PowerUpController.Powerup.TwoXMultiplier);
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Bomb"))
        {
            _scoreManager.RemoveLives(1);
            other.gameObject.SetActive(false);
        }
    }
}
