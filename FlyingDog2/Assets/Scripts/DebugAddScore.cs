using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugAddScore : MonoBehaviour
{
    public GameObject updateScore;

    public void AddScoreClick()
    {
        updateScore.GetComponent<UpdateScore>().scoreAmount += 1;
    }
}
