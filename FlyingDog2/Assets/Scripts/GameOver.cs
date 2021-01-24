using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool isAlive;
    public GameObject pausePanel;

    private void Start()
    {
        isAlive = true;
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (!isAlive)
        {
            // Pause time
            Time.timeScale = 0;
            // Activate UI
            pausePanel.SetActive(true);
        }
    }
}
