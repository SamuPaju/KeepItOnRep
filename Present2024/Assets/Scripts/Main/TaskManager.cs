using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] GameObject cameraMain;
    [SerializeField] GameObject cameraTask;

    [Header("UI")]
    [SerializeField] GameObject taskUI;
    [SerializeField] GameObject cursor;

    [Header("Other variables")]
    public bool atTable;
    [SerializeField] PlayerController playerController;
    [SerializeField] Axe axe;
    [SerializeField] AudioSource wrappingSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AwayFromTheTable();
        }
    }

    /// <summary>
    /// Set up everything for going to table
    /// </summary>
    public void AtTheTable()
    {
        // Turn off
        cameraMain.SetActive(false);
        cursor.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        GetComponent<SphereCollider>().enabled = false;
        playerController.disableMove();

        // Turn on
        cameraTask.SetActive(true);
        taskUI.SetActive(true);
        atTable = true;
    }

    /// <summary>
    /// Resets everything to normal gameplay
    /// </summary>
    public void AwayFromTheTable()
    {
        // Turn on
        cameraMain.SetActive(true);
        cursor.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<SphereCollider>().enabled = true;
        playerController.activateMove();
        axe.SetBack();

        // Turn off
        cameraTask.SetActive(false);
        taskUI.SetActive(false);
        atTable = false;
        wrappingSound.mute = true;
    }
}
