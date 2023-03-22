using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Game Timer Class
/// 
/// Contains the functionality to measure how long an average run for the player is made. It is displayed both in the main game
/// and in the final results screen before the player is prompted to try again or not.
/// </summary>

public class GameTimer : MonoBehaviour
{
    //Assigned variables with necessary values.
    [Header("Assigned Components")]
    public static GameTimer timerInstance;
    public TextMeshProUGUI displayedTime;

    [Header("Timer Settings")]
    public float currentTime;

    [Header("Timer Check")]
    public bool timerGoingCheck;
    public TimeSpan timePassed;

    void Awake()
    {
        timerInstance = this;
    }

    //The current time is equal to the starting time upon when the game runs
    void Start()
    {
        displayedTime.text = "00:00";
        timerGoingCheck = false;
    }

    public void BeginTimer()
    {
        timerGoingCheck = true;
        currentTime = 0f;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoingCheck = false;
    }

    public IEnumerator UpdateTimer()
    {
        while(timerGoingCheck)
        {
            currentTime += Time.deltaTime;
            timePassed = TimeSpan.FromSeconds(currentTime);
            string timePassesStr = timePassed.ToString("mm':'ss");
            displayedTime.text = timePassesStr;

            yield return null;
        }
    }
}
