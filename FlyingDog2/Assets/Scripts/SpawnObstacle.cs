using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    private Vector3 leftPos;
    private Vector3 rightPos;
    private Vector3 midPos;

    public bool waitingSpawn;

    // Limit spawn amounts per position
    private int leftAmount;
    private int rightAmount;
    private int midAmount;
    public float spawnLeft = -4f;
    public float spawnRight = 4f;
    public float spawnMid = 0f;

    // Change position counter
    public int changePos;

    // Make obstacles go faster based on score
    public SpeedSO speedSO;

    // Start is called before the first frame update
    void Start()
    {
        // Need to resume time after replay so always set timescale here to begin game
        Time.timeScale = 1;

        waitingSpawn = true;
        leftAmount = 0;
        rightAmount = 0;
        midAmount = 0;

        // In lack of better place to reset speedSO
        // I do it here because SpawnObstacle.cs is present through entire gameplay
        speedSO.speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        changePos = GameObject.Find("Canvas").GetComponent<UpdateScore>().scoreAmount;
        // "Randomize" spawn position based on score amount
        if (changePos > 5)
        {
            spawnLeft = -2f;
            spawnRight = 3f;
            spawnMid = 1f;
            speedSO.speed = 7.66f;

            if (changePos > 10)
            {
                spawnLeft = -5f;
                spawnRight = 6f;
                spawnMid = -1f;
                speedSO.speed = 9.66f;
            }

            if (changePos > 15)
            {
                spawnLeft = -6f;
                spawnRight = 7f;
                spawnMid = 1f;
                // Update speed scriptableobject that affects all objects with it assigned
                speedSO.speed = 12.66f;
            }
        }

        leftPos = transform.position + new Vector3(spawnLeft, 0, 0);
        rightPos = transform.position + new Vector3(spawnRight, 0, 0);
        midPos = transform.position + new Vector3(spawnMid, 0, 0);
        // Check the random result and spawn obstacle
        if (waitingSpawn)
            StartCoroutine(RandomSpawnerGenerator());
    }

    // Spawn Timer
    IEnumerator RandomSpawnerGenerator()
    {
        waitingSpawn = false;
        int result;
        result = Random.Range(1, 4);

        switch (result)
        {
            case 1:
                if (leftAmount >= 1)
                {
                    Instantiate(prefab, rightPos, Quaternion.Euler(0, 0, 0));
                    rightAmount++;
                    leftAmount = 0;
                    midAmount = 0;
                }
                else
                {
                    Instantiate(prefab, leftPos, Quaternion.Euler(0, 0, 0));
                    leftAmount++;
                }
                break;
            case 2:
                if (rightAmount >= 1)
                {
                    Instantiate(prefab, leftPos, Quaternion.Euler(0, 0, 0));
                    leftAmount++;
                    rightAmount = 0;
                    midAmount = 0;
                }
                else
                {
                    Instantiate(prefab, rightPos, Quaternion.Euler(0, 0, 0));
                    rightAmount++;
                }
                break;
            case 3:
                if (midAmount >= 1)
                {
                    Instantiate(prefab, leftPos, Quaternion.Euler(0, 0, 0));
                    leftAmount++;
                    rightAmount = 0;
                }
                else
                {
                    Instantiate(prefab2, midPos, Quaternion.Euler(0, 0, 0));
                    midAmount++;
                }
                break;
        }
        yield return new WaitForSeconds(1);
        waitingSpawn = true;
    }
}
