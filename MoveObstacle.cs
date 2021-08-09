using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    // Use a ScriptableObject to store speed value so we can modify them at anytime
    public SpeedSO speedSO;

    private void Start()
    {
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, -1 * speedSO.speed * Time.deltaTime, 0);
    }
}
