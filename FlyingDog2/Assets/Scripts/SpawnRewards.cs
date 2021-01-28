using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRewards : MonoBehaviour
{
    public GameObject prefab;
    private Vector3 leftPos;
    private Vector3 rightPos;
    private Vector3 midPos;

    public bool waitingSpawn;

    // Limit spawn amounts per position
    private int leftAmount;
    private int rightAmount;
    private int midAmount;
    public float spawnLeft = -2f;
    public float spawnRight = 2f;
    public float spawnMid = -5f;

    // Change position counter
    public int changePos;

    // Start is called before the first frame update
    void Start()
    {
        waitingSpawn = true;
        leftAmount = 0;
        rightAmount = 0;
        midAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        changePos = GameObject.Find("Canvas").GetComponent<UpdateScore>().scoreAmount;
        // "Randomize" spawn position based on score amount
        if (changePos > 5)
        {
            spawnLeft = -8f;
            spawnRight = 5f;
            spawnMid = 3f;

            if (changePos > 10)
            {
                spawnLeft = -3f;
                spawnRight = 8f;
                spawnMid = -6f;
            }

            if (changePos > 15)
            {
                spawnLeft = -2f;
                spawnRight = 4f;
                spawnMid = 8f;
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
                if (midAmount >= 0)
                {
                    Instantiate(prefab, midPos, Quaternion.Euler(0, 0, 0));
                    midAmount++;
                    rightAmount = 0;
                    leftAmount = 0;
                }
                break;
        }
        yield return new WaitForSeconds(1.33f);
        waitingSpawn = true;
    }
}
