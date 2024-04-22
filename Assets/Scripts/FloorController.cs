using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    private ScoreManager _scoreManager;
    
    private void Awake()
    {
        _scoreManager = GameObject.FindWithTag("GameController").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Throwable"))
        {
            _scoreManager.RemoveLives(1);
            other.gameObject.SetActive(false);
        }
        
        if (other.gameObject.CompareTag("PowerupAddLife"))
        {
            _scoreManager.PowerupLost();
            other.gameObject.SetActive(false);
        }
        
        if (other.gameObject.CompareTag("PowerupMagnet"))
        {
            _scoreManager.PowerupLost();
            other.gameObject.SetActive(false);
        }
        
        if (other.gameObject.CompareTag("PowerupMultiplier"))
        {
            _scoreManager.PowerupLost();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.gameObject.CompareTag("Bomb"))
        {
            _scoreManager.AddPoints(2);
            other.gameObject.SetActive(false);
        }
    }
}
