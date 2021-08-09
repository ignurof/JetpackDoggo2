using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public GameObject scoreCounter;
    public int scoreAmount;

    // Update is called once per frame
    void Update()
    {
        scoreCounter.GetComponent<TMP_Text>().text = scoreAmount.ToString();
    }
}
