using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Some methods to help with the start sequence
/// Used as events in animations
/// </summary>
public class StartSequenceCamera : MonoBehaviour
{
    [SerializeField] Animator decAxeAnim;

    public void Dialog()
    {
        TextManager.instance.DisplayLines("I have to go get some firewood.", true);
    }

    public void Pick()
    {
        decAxeAnim.SetTrigger("Pick");
    }

    public void End()
    {
        GameManager.instance.StartSequenceEnd();
    }
}
