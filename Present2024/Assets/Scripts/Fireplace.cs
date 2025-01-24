using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fireplace : MonoBehaviour
{
    public float timeLeft = 60f;
    public float maxTime = 60f;
    [SerializeField] float woodTimeValue = 5f;
    public Image fireplace;
    public float lerpSpeed;
    bool timerGoing = true;
    public int timeFactor = 1;
    [SerializeField] Door door;
    bool firstTime = true;

    private void Awake()
    {
        timeLeft = maxTime;
        DisplayTime();
    }

    void Update()
    {
        // If door is open douple the time timer goes
        if (door.openClose == false)
        {
            timeFactor = 1;
        }
        else
        {
            timeFactor = 2;
        }
        if (timerGoing)
        {
            timeLeft -= Time.deltaTime * timeFactor;
            DisplayTime();

            if (timeLeft < 0)
            {
                GameManager.instance.GameOver(false);
            }            
        }
    }

    /// <summary>
    /// Displays time that's left before the fireplace goes out
    /// </summary>
    void DisplayTime()
    {
        if (timeLeft != fireplace.fillAmount)
        {
            fireplace.fillAmount = Mathf.Lerp(fireplace.fillAmount, timeLeft / maxTime, Time.deltaTime * lerpSpeed);
        }
    }

    /// <summary>
    /// Adds 1 wood to fireplace and adds the amount of woodTimeValue
    /// </summary>
    public void Addwood()
    {
        // Gives voicelines when the first firewood is added
        if (firstTime)
        {
            TextManager.instance.DisplayLines("I should also wrap up the gifts on the table.", true);
            firstTime = false;
        }
        timeLeft += woodTimeValue;
        if (timeLeft >= maxTime + 2)
        {
            timeLeft = maxTime;
            TextManager.instance.DisplayLines("I shouldn't add more wood.", true);
        }
        Inventory.instance.wood -= 1;
    }

    /// <summary>
    /// Stops the timer
    /// </summary>
    public void disableTimer()
    {
        timerGoing = false;
    }
    /// <summary>
    /// Activates the timer
    /// </summary>
    public void activateTimer()
    {
        timerGoing = true;
    }
}
