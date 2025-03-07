﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        // Make sure the game knows the player is dead
        GameObject.Find("Canvas").GetComponent<GameOver>().isAlive = false;
    }
}
