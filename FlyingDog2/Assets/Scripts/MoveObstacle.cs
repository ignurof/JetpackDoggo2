using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        speed = 6f;
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, -1 * speed * Time.deltaTime, 0);
    }

    public void SetSpeed(float x)
    {
        speed = x;
    }
}
