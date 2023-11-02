using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownManager : MonoBehaviour
{
    GameManagerX gameManagerX;
    TextMeshProUGUI timerText;
    float timer = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerX.isGameActive)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time:" + Mathf.Round(timer);
        }

    }
}
