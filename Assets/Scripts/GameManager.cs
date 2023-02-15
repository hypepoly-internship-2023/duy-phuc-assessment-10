using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 60;
    [SerializeField] private TMP_Text timeText;

    [HideInInspector]
    public static GameManager instance;

    public string state = "PLAY";

    private void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if(state == "PLAY")
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        if(timeText)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
