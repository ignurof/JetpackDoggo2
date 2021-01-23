using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private bool isStart;
    public float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        StartCoroutine(SlowStartTimer());
    }

    // Update is called once per frame
    void Update()
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

    IEnumerator SlowStartTimer()
    {
        yield return new WaitForSeconds(6);
        isStart = true;
    }
}
