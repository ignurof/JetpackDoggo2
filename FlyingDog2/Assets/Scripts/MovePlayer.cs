using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public SpeedSO speedSO;
    private float speed;

    // Vector2 is like GetAxis
    private Vector2 direction;

    public void Controls(InputAction.CallbackContext context)
    {
        // Move Action is a Vector2 so we set the direction based on values returned from Move action whenever a Move action key is pressed
        direction = context.ReadValue<Vector2>(); 
    }

    private void FixedUpdate()
    {
        // Restrict movement to game view
        if (transform.position.x <= -8f)
            transform.position = new Vector2(-8f, transform.position.y);
        else if (transform.position.x >= 8f)
            transform.position = new Vector2(8f, transform.position.y);

        // Adjust speed based on ObstacleSpeed
        speed = speedSO.speed + 2f;

        // For example, when we hold D, x is 1, if we hold A, x is -1
        transform.Translate(direction.x * speed * Time.deltaTime, 0, 0);
    }
}
