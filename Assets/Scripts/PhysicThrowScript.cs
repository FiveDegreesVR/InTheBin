using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicThrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPoints;
    //spawnPoints is the places where the items can spawn
    public int spawnCount;
    //total number of SpawnPoints to save myself from calling spawnPoints.length 50,000 times
    public GameObject[] throwablesPrefabs;
    //This throwables prefabs is for the items we want to throw through the physics script
    private GameObject[][] throwables;
    //This is jagged array is for the items to be initialized and cycled through for better usage of memory, cpu, and ram
    private int[] tracker;
    //tracker is to know which item in throwables is to be instantialized next
    //starts at 0 and once it meets the maxNumItem, then go back to 0.
    private int maxNumOfItem = 10;
    //So this max num of items variable is the maximum total number of a specific item that can spawn at one given time
    private int numOfItemSpawn = 2;
    //This numOfItemSpawn will be used in tandem with a random function to determine the number of items that spawn and what kind
    //This variable will periodically increase throughout the length of the game.
    private System.Random rand = new System.Random();

    private int randResult = 0;
    //randResult is just a variable to be used in tandem with rand
    private int randItem = 0;
    //randItem is just a variable to be used in tandem with rand to determine the random item spawned

    private int numberOfThrowables = 0;
    //numberOfThrowables is to just save myself from having to call throwablesPrefabs.length 50,000 times
    private void OnAwake()
    {
        
    }
    void Start()
    {
        spawnCount = spawnPoints.Length;
        numberOfThrowables = throwablesPrefabs.Length;
        throwables = new GameObject[numberOfThrowables][];
        tracker = new int[numberOfThrowables];
        //
        for(int i = 0; i < numberOfThrowables; i++)
        {
            throwables[i] = new GameObject[maxNumOfItem];
            tracker[i] = 0;
            for (int j = 0; j < maxNumOfItem; j++)
            {
                throwables[i][j] = Instantiate(throwablesPrefabs[i]);
                throwables[i][j].SetActive(false);
                //This makes a set of n items, n being the length of the throwables prefabs
                //and a total of maxNumOfItem copies of the same item.
            }
        }
    }

    private void FixedUpdate()
    {
        randResult =  rand.Next(1, numOfItemSpawn);
        for(int i = 0; i < randResult; i++)
        {
            randItem = rand.Next(0, numberOfThrowables);
            //do something with...
            ThrowItem(i, randItem);
        }
    }

    public void ThrowItem(int iterator, int randVal)
    {
        throwables[randVal][tracker[iterator]].SetActive(true);
        throwables[randVal][tracker[iterator]++].transform.position = spawnPoints[rand.Next(0, spawnCount)].position;
        if(tracker[iterator] >= maxNumOfItem)
        {
            tracker[iterator] = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}