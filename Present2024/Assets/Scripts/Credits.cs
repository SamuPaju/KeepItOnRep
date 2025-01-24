using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

/// <summary>
/// Handles credits sequence
/// </summary>
public class Credits : MonoBehaviour
{
    [SerializeField] GameObject mainCredits;
    [SerializeField] GameObject sideCredits;

    private void Start()
    {
        // Puts main credits on and starts a coroutine to switch it
        mainCredits.SetActive(true);
        sideCredits.SetActive(false);
        StartCoroutine(MainToSide());
    }

    /// <summary>
    /// Switches main credits to side credits and sarts a coroutine to go back to start menu
    /// </summary>
    /// <returns></returns>
    IEnumerator MainToSide()
    {
        yield return new WaitForSeconds(4);
        mainCredits.SetActive(false);
        sideCredits.SetActive(true);
        StartCoroutine(SideToStart());
    }

    /// <summary>
    /// Goes to start menu after given time
    /// </summary>
    /// <returns></returns>
    IEnumerator SideToStart()
    {
        yield return new WaitForSeconds(8);
        GameManager.instance.Restart();
    }
}
