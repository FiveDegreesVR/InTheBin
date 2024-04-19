using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PhysicThrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPoints;
    //spawnPoints is the places where the items can spawn
    public int spawnCount;
    //total number of SpawnPoints to save myself from calling spawnPoints.length 50,000 times
    public GameObject[] throwablesPrefabs;
    public GameObject[] powerupPrefabs;
    //This throwables prefabs is for the items we want to throw through the physics script
    public GameObject[][] throwables;
    private List<GameObject> powerupInstances = new List<GameObject>();
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

    private float spawnRate = 2.0f;

    private float time = 0;
    
    private PersistentDataObject _persistentDataObject;

    private int spawnedItemCount = 0;
    private int indexInSpawnList = 0;
    public int numOfItemsToSpawnBeforePowerup = 15;
    
    void Start()
    {
        _persistentDataObject = GameObject.FindWithTag("Persistent").GetComponent<PersistentDataObject>();
        switch (_persistentDataObject.activeDifficulty)
        {
            case Difficulty.Easy:
                spawnRate = 2.0f;
                break;
            case Difficulty.Medium:
                spawnRate = 1.25f;
                break;
        }
        
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
                throwables[i][j] = Instantiate(throwablesPrefabs[i], transform);
                throwables[i][j].SetActive(false);
                //This makes a set of n items, n being the length of the throwables prefabs
                //and a total of maxNumOfItem copies of the same item.
            }
        }
        
        // Debug.Log(powerupPrefabs.Length);

        foreach (GameObject prefab in powerupPrefabs)
        {
            GameObject instanceObj = Instantiate(prefab, transform);
            powerupInstances.Add(instanceObj);
            instanceObj.SetActive(false);
        }
        
        spawnedItemCount = 0;
        indexInSpawnList = 0;
    }

    private void FixedUpdate()
    {
        if (spawnRate <= time)
        {
            time = 0;
            randResult = rand.Next(1, numOfItemSpawn);
            for (int i = 0; i < randResult; i++)
            {
                randItem = rand.Next(0, numberOfThrowables);
                //do something with...
                ThrowItem(i, randItem);
            }
        }
    }

    public void ThrowItem(int iterator, int randVal)
    {
        GameObject objToThrow = throwables[randVal][tracker[iterator]];
        if (!objToThrow.activeSelf)
        {
            objToThrow.SetActive(true);
            spawnedItemCount++;
            objToThrow.transform.position = (spawnPoints[rand.Next(0, spawnCount)].position + new Vector3(Random.Range(-0.5f,0.5f),0,0));
            objToThrow.transform.Rotate(Vector3.forward, Random.Range(-90f,90f));
            if(tracker[iterator] >= maxNumOfItem)
            {
                tracker[iterator] = 0;
            }
        }
        else
        {
            time = spawnRate;
        }

        if (spawnedItemCount > numOfItemsToSpawnBeforePowerup)
        {
            Invoke(nameof(SpawnPowerup),5.0f);
            spawnedItemCount = 0;
        }
    }

    private void SpawnPowerup()
    {
        if (indexInSpawnList >= powerupInstances.Count)
        {
            powerupInstances = powerupInstances.OrderBy( x => Random.value ).ToList( );
            indexInSpawnList = 0;
        }
        
        if (indexInSpawnList < powerupInstances.Count)
        {
            powerupInstances[indexInSpawnList].SetActive(true);
            powerupInstances[indexInSpawnList].transform.position = (spawnPoints[rand.Next(0, spawnCount)].position + new Vector3(Random.Range(-0.5f,0.5f),0,0));
            powerupInstances[indexInSpawnList].transform.Rotate(Vector3.forward, Random.Range(-90f,90f));
            indexInSpawnList++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
