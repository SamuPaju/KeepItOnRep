using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasTree : MonoBehaviour
{
    [SerializeField] GameObject[] presents;
    int presentIndex = 0;

    /// <summary>
    /// Handles presents under christmastree
    /// </summary>
    public void placePresent()
    {
        presents[presentIndex].gameObject.SetActive(true);
        presentIndex++;
        Inventory.instance.placePresent();

        // Checks if all the presents are added
        // And if they are start a coroutine to win the game
        if (presentIndex >= presents.Length)
        {
            TextManager.instance.DisplayLines("Finally. All gifts are wrapped and ready.", false);
            StartCoroutine(BeforeVictory());
        }
    }

    /// <summary>
    /// After given time activates victory
    /// </summary>
    /// <returns></returns>
    IEnumerator BeforeVictory()
    {
        yield return new WaitForSeconds(5);
        TextManager.instance.HideLines();
        GameManager.instance.GameOver(true);
    }
}
