using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float speed = 6f;

    // Vector2 is like GetAxis
    private Vector2 direction;

    public void Controls(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>(); 
    }

    private void FixedUpdate()
    {
        transform.Translate(direction.x * speed * Time.deltaTime, 0, 0);
    }
}
