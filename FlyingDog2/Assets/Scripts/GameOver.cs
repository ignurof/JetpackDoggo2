using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public bool isAlive;
    public GameObject pausePanel;

    private float coolTimer;

    private void Start()
    {
        isAlive = true;
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        coolTimer += Time.deltaTime;
        if (!isAlive)
        {
            // Pause time
            Time.timeScale = 0;
            // Activate UI
            pausePanel.SetActive(true);

            pausePanel.transform.GetChild(4).GetComponent<TMP_Text>().text = "Time: " + coolTimer;
        }
    }

    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
