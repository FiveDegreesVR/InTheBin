using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanController : MonoBehaviour
{
    private ScoreManager _scoreManager;
    
    private void Awake()
    {
        //_scoreManager = GameObject.FindWithTag("GameController").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable"))
        {
            _scoreManager.AddPoints(2);
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Bomb"))
        {
            _scoreManager.RemoveLives(1);
            other.gameObject.SetActive(false);
        }
    }
}
