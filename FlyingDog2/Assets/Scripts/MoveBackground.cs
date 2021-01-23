using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private bool isStart;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        StartCoroutine(MoveBGTimer());
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
            }
        }
    }

    IEnumerator MoveBGTimer()
    {
        yield return new WaitForSeconds(8);
        isStart = true;
    }


}
