using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int addAmount;

    // Using this to reset player position, otherwise it goes down from collision
    private Vector2 oldPos;

    private void Update()
    {
        oldPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = oldPos;
        if (collision.gameObject.CompareTag("Hamburger"))
        {
            Destroy(collision.gameObject);
            GameObject.Find("Canvas").GetComponent<UpdateScore>().scoreAmount += 1;
        }
    }
}
