using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Counts the game time
/// </summary>
public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float time;
    bool isRunning = false;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;
        }
    }

    /// <summary>
    /// Turns timer on
    /// </summary>
    public void timerOn()
    {
        isRunning = true;
    }
    /// <summary>
    /// Turns timer off
    /// </summary>
    /// <returns>Time played</returns>
    public float TimerOff()
    {
        isRunning = false;
        return time;
    }
}
