using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private bool isStart;
    public float speed = 2f;
    public GameObject prefab;

    // Keep track of scoreCounter on UpdateScore.cs
    public GameObject scoreObj;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
    }

    private void Update()
    {
        // Move the obstacle only if X amount of score
        score = scoreObj.GetComponent<UpdateScore>().scoreAmount;
        if (score > 10)
        {
            StartCoroutine(MoveBGTimer());
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
                isStart = false;
                // Update obstacle speed
                prefab.GetComponent<MoveObstacle>().SetSpeed(10f);
            }
        }
    }

    IEnumerator MoveBGTimer()
    {
        yield return new WaitForSeconds(8);
        isStart = true;
    }


}
