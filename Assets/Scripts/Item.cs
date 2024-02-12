using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    int points = 0;
    // public static float gravity = 8.5f;
    // public static float gravity_strength = 10;

    static int difficultyLevel = 0;
    static  int maxDifficulty = 1;
    //public static bool difficulty1 = true;
    //public static bool difficulty2 = false;

    public bool change = false;
    protected void SetNewPoint(int point)
    {
        points = point;
    }
    void Start()
    {
        
    }
    void OnEnable()
    {
        // this.GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity, 0) * gravity_strength);
    }
    // Update is called once per frame
    // void Update()
    // {
    //     if (change)
    //     {
    //         change = false;
    //         changeDifficulty();
    //     }
    // }

    // public static void changeDifficulty()
    // {
    //     difficultyLevel++;
    //     if(difficultyLevel > maxDifficulty)
    //     {
    //         difficultyLevel = 0;
    //     }
    //     switch(difficultyLevel)
    //     {
    //         case 0:
    //             gravity = 8.5f;
    //             gravity_strength = 15f;
    //             break;
    //         case 1:
    //             gravity = 8.5f;
    //             gravity_strength = 30f;
    //             break;
    //     }
    // }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if(other.gameObject.CompareTag("Caught"))
    //     {
    //         ScoreManager.gotPoints(points);
    //         this.gameObject.SetActive(false);
    //         //Debug.Log("Scored");
    //     }
    //     else if(other.gameObject.CompareTag("Floor"))
    //     {
    //         this.gameObject.SetActive(false);
    //     }
    // }
}
