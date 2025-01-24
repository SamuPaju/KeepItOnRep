using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    [SerializeField] float hideTime = 2.5f;

    [Header("UI Instructions")]
    [SerializeField] GameObject panelInstruction;
    [SerializeField] TextMeshProUGUI textInstructions;

    [Header("UI Voicelines")]
    [SerializeField] GameObject panelLines;
    [SerializeField] TextMeshProUGUI textLines;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Gives instruction to player with the given statement
    /// </summary>
    /// <param name="instruction"></param>
    public void GiveInstruction(string instruction)
    {
        panelInstruction.SetActive(true);
        textInstructions.text = instruction;
    }

    /// <summary>
    /// Hides the instruction and set the instruction back to default debug version
    /// </summary>
    public void HideInstructions()
    {
        panelInstruction.SetActive(false);
        textInstructions.text = "Instructions for player debug";
    }

    /// <summary>
    /// Displays given text as a voiceline
    /// </summary>
    /// <param name="line"></param>
    public void DisplayLines(string line, bool hideAutomatically)
    {
        panelLines.SetActive(true);
        textLines.text = line;
        if (hideAutomatically)
        {
            StartCoroutine(GoToHide());
        }
    }

    /// <summary>
    /// Hides the lines and sets the text back to default
    /// </summary>
    public void HideLines()
    {
        panelLines.SetActive(false);
        textLines.text = "This is a debug message. If you see this something went horribly wrong.";
    }

    /// <summary>
    /// Waits given time and then goes to HideLines
    /// </summary>
    /// <returns></returns>
    IEnumerator GoToHide()
    {
        yield return new WaitForSeconds(hideTime);
        HideLines();
    }
}
