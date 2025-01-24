using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSequence : MonoBehaviour
{
    [SerializeField] GameObject matchstickFire;
    [SerializeField] GameObject fireplaceFire;
    [SerializeField] GameObject fireplacelight;
    [SerializeField] GameObject matchBox;
    [SerializeField] Animator cameraAnim;

    private void Start()
    {
        // Makes sure that fireplace is off
        fireplaceFire.SetActive(false);
        fireplacelight.SetActive(false);
    }

    /// <summary>
    /// Lights the fire with the matchstick for a short time to make it look like it sparks
    /// </summary>
    /// <returns></returns>
    public IEnumerator Spark()
    {
        matchstickFire.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        matchstickFire.SetActive(false);
    }

    /// <summary>
    /// Lights the matchstick and keeps it on
    /// </summary>
    public void IgniteStick()
    {
        matchstickFire.SetActive(true);
    }

    /// <summary>
    /// Event for animation
    /// Uses TextManager to display voicelines
    /// </summary>
    public void Talk()
    {
        TextManager.instance.DisplayLines("Come on!", true);
    }

    /// <summary>
    /// Lights the fireplace
    /// </summary>
    public void IgniteFireplace()
    {
        fireplaceFire.SetActive(true);
        fireplacelight.SetActive(true);
    }

    /// <summary>
    /// Disables matchstick and matchbox
    /// </summary>
    public void StickOut()
    {
        gameObject.SetActive(false);
        matchBox.SetActive(false);
    }

    /// <summary>
    /// Moves the matchbox out of the way
    /// </summary>
    public void BoxGo()
    {
        matchBox.GetComponent<Animator>().SetTrigger("GoGoGo");
        cameraAnim.SetTrigger("MoveIt");
    }
}
