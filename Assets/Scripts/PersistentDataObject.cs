using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

