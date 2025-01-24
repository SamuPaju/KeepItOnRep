using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskCamera : MonoBehaviour
{
    [Header("Looking up and down variables")]
    [SerializeField] GameObject upUI;
    [SerializeField] GameObject downUI;
    public bool lookingUp = true;
    Vector3 m_up = new Vector3(9.5f, 153, 0);
    Vector3 m_down = new Vector3(40, 153, 0);

    // Raycast
    RaycastHit hit;
    Vector3 screenPosition;

    [Header("Indicators")]
    [SerializeField] GameObject indicator1;
    [SerializeField] GameObject indicator2;

    // Bools for timing
    bool getPresent = true;
    bool hasPresent = false;
    bool somethingToWrap;

    [Header("Present objects")]
    public GameObject[] presentsAtSide;
    public GameObject[] unpackedPresents;
    public GameObject[] packedPresents;
    public int currentPresents = 0;

    // Wrapping variables
    public float wrapTime = 5f;
    public float currentTime;
    [SerializeField] Image slider;
    [SerializeField] GameObject wrappingslider;


    void Update()
    {
        screenPosition = Input.mousePosition;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(screenPosition);

        // Check if Raycast hit anything with Detec1 or Detec2 tag
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Detec1" || hit.collider.tag == "Detec2")
        {
            // Check if looking at the unwrapped presents at the side of the table
            // and that other variables are correct
            if (hit.collider.tag == "Detec1" && getPresent && !lookingUp)
            {
                indicator1.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    GetPresent();
                }
            }
            else
            {
                indicator1.SetActive(false);
            }
            // Check if looking at the unwrapped present int the middle of table
            // and that other variables are correct
            if (hit.collider.tag == "Detec2" && hasPresent && !lookingUp)
            {
                indicator2.SetActive(true);
                WrapThePresent();
            }
            else
            {
                indicator2.SetActive(false);
            }
        }
        else
        {
            indicator1.SetActive(false);
            indicator2.SetActive(false);
            TextManager.instance.HideInstructions();
        }

    }

    /// <summary>
    /// Makes the camera face at the table
    /// </summary>
    public void LookDown()
    {
        upUI.SetActive(false);
        downUI.SetActive(true);
        transform.eulerAngles = m_down;
        lookingUp = false;
    }

    /// <summary>
    /// Makes the camera face strait
    /// </summary>
    public void LookUp()
    {
        upUI.SetActive(true);
        downUI.SetActive(false);
        transform.eulerAngles = m_up;
        lookingUp = true;
    }

    /// <summary>
    /// Grabs the present to be packed
    /// </summary>
    void GetPresent()
    {
        presentsAtSide[currentPresents].SetActive(false);
        unpackedPresents[currentPresents].SetActive(true);
        getPresent = false;

        // Set wrapping possible
        hasPresent = true;
        somethingToWrap = true;
        currentTime = 0;
    }

    /// <summary>
    /// Packs the present
    /// </summary>
    void WrapThePresent()
    {
        if (Input.GetMouseButton(0) && somethingToWrap)
        {
            wrappingslider.SetActive(true);
            currentTime += Time.deltaTime;
            slider.fillAmount = Mathf.Lerp(slider.fillAmount, currentTime / wrapTime, Time.deltaTime * 5);
            indicator2.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            indicator2.GetComponent<AudioSource>().mute = true;
        }

        if (currentTime >= wrapTime)
        {
            unpackedPresents[currentPresents].SetActive(false);
            packedPresents[currentPresents].SetActive(true);
            somethingToWrap = false;
            TakeThePresent();
        }
    }

    /// <summary>
    /// Take the present to inventory
    /// </summary>
    void TakeThePresent()
    {
        TextManager.instance.GiveInstruction("RMB to take the present");
        if (Input.GetMouseButton(1))
        {
            TextManager.instance.HideInstructions();
            wrappingslider.SetActive(false);

            // This is here for the Scare2 sound
            currentTime = 0;

            slider.fillAmount = 0;
            packedPresents[currentPresents].SetActive(false);
            Inventory.instance.present++;
            currentPresents++;
            // As long as current presents are lower than the amount of presents at the side of the table
            // set the bool back normal so the packing loop begins agen
            if (currentPresents < presentsAtSide.Length)
            {
                getPresent = true;
                hasPresent = false;
            }
            // When all presents are wrapped give player instructions and disable wrapping loop
            else
            {
                TextManager.instance.DisplayLines("All gifts are now wrapped. Time to put them under the tree.", true);
                getPresent = false;
                hasPresent = false;
            }
        }
    }
}
