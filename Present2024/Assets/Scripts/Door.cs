using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] GameObject doorTurner;
    [SerializeField] int angle;
    public bool openClose = false;

    float timeOpen;

    private void Update()
    {
        // Check if door is open or closed
        if (openClose)
        {
            timeOpen += Time.deltaTime;
            // If door is open long enough give player instructions as voiceline
            if (timeOpen > 15)
            {
                TextManager.instance.DisplayLines("I should close the door so the fire doesn't go out faster!", false);
                StartCoroutine(HideText());
                timeOpen = 0;
            }
        }
        else
        {
            timeOpen = 0;
        }
    }

    /// <summary>
    /// Hides voicelines after 5 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator HideText()
    {
        yield return new WaitForSeconds(5f);
        TextManager.instance.HideLines();
    }

    /// <summary>
    /// Opens and closes door
    /// </summary>
    public void DoorActivate()
    {
        if (openClose)
        {
            doorTurner.transform.rotation = Quaternion.Euler(0, 0, 0);
            openClose = false;
        }
        else
        {
            doorTurner.transform.rotation = Quaternion.Euler(0, angle, 0);
            openClose = true;
        }
    }
}
