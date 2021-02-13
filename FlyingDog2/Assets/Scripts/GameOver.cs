using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool isAlive;
    public GameObject pausePanel;
    public GameObject scoreObj;

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
            AudioListener.pause = true;
            // Activate UI
            pausePanel.SetActive(true);

            pausePanel.transform.GetChild(4).GetComponent<TMP_Text>().text = "Time: " + coolTimer;
            scoreObj.transform.localPosition = new Vector3(0, -10f, 0);
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        /*
         * OLD WAY, this is useful for future reference
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        */
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }
}
