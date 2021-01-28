using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private bool isStart;
    private bool isStartTwo;

    public float speed = 2f;

    // Keep track of scoreCounter on UpdateScore.cs
    public GameObject scoreObj;
    private int score;

    private bool firstCompleted;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        isStartTwo = false;
        firstCompleted = false;
    }

    private void Update()
    {
        // Move the obstacle only if X amount of score
        score = scoreObj.GetComponent<UpdateScore>().scoreAmount;
        if (score > 10 && !firstCompleted)
        {
            StartCoroutine(MoveBGTimer());
        }
        if(score > 20 && firstCompleted)
        {
            StartCoroutine(MoveBGTimerTwo());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStart)
        {
            transform.Translate(0, -1 * speed * Time.deltaTime, 0);
            if (transform.position.y <= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                isStart = false;
            }
        }

        if (isStartTwo)
        {
            transform.Translate(0, -1 * speed * Time.deltaTime, 0);
            if(transform.position.y <= -10f)
            {
                transform.position = new Vector3(transform.position.x, -10f, transform.position.z);
                isStartTwo = false;
            }
        }
    }

    IEnumerator MoveBGTimer()
    {
        yield return new WaitForSeconds(8);
        isStart = true;
        firstCompleted = true;
    }

    IEnumerator MoveBGTimerTwo()
    {
        yield return new WaitForSeconds(8);
        isStartTwo = true;
    }
}
