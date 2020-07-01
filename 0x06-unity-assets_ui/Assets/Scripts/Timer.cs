﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Represents the Timer.
/// </summary>
public class Timer : MonoBehaviour
{
    public GameObject WinCanvas;
    public Text TimerText;
    public Text FinalTime;
    private float time = 0f;
    private bool stop = false;

    /// <summary>
    /// Updates the timer UI.
    /// </summary>
    void Update()
    {
        if (stop == false)
        {
            time += Time.deltaTime;
            TimerText.text = string.Format("{0:0}:{1:00}.{2:00}", time / 60, time % 60, time * 100 % 100);
        }
    }

    /// <summary>
    /// Displays the win UI.
    /// </summary>
    public void Win()
    {
        WinCanvas.SetActive(true);
        FinalTime.text = string.Format("{0:0}:{1:00}.{2:00}", time / 60, time % 60, time * 100 % 100);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Stops the timer when player reaches the goal.
    /// </summary>
    /// <param name="other">The collider that touches the player.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WinFlag")
        {
            stop = true;
            TimerText.fontSize = 60;
            TimerText.color = Color.green;
            Win();
        }
    }
}
