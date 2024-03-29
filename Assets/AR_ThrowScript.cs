using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_ThrowScript : MonoBehaviour
{
    bool spawned = false;
    //when the player is spawned then this becomes true.
    bool started = true;
    //When the player is spawned then it allows the starting methods to run 1 time.
    GameObject playerTrash;
    //is a reference to the player object
    // Start is called before the first frame update
    Transform[] spawnPoints;
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

    private float spawnRate = 2.0f;

    private float time = 0;

    private PersistentDataObject _persistentDataObject;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (spawned && started)
        {
            time = 0;
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
            for (int i = 0; i < numberOfThrowables; i++)
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
            started = false;
        }
        else if (!spawned)
        {
            //checks if the player has been spawned yet
            GameObject[] stuff = GameObject.FindGameObjectsWithTag("TrashCan");
            if (stuff.Length > 0)
            {
                playerTrash = stuff[0];
                GameObject[] spawns = GameObject.FindGameObjectsWithTag("DropPoints");
                spawnPoints = new Transform[spawns.Length];
                for(int i = 0; i < spawns.Length; i++)
                {
                    spawnPoints[i] = spawns[i].transform;
                }

                spawned = true;
            }
        }
        else
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
    }

    public void ThrowItem(int iterator, int randVal)
    {
        GameObject objToThrow = throwables[randVal][tracker[iterator]];
        if (!objToThrow.activeSelf)
        {
            objToThrow.SetActive(true);
            objToThrow.transform.position = (spawnPoints[rand.Next(0, spawnCount)].position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0));
            objToThrow.transform.Rotate(Vector3.forward, Random.Range(-90f, 90f));
            if (tracker[iterator] >= maxNumOfItem)
            {
                tracker[iterator] = 0;
            }
        }
        else
        {
            time = spawnRate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
