using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    bool ableToLook = true;

    RaycastHit hit;
    [SerializeField] float rayRange = 5f;

    void Start()
    {
        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Check if the player is allowed to look
        if (ableToLook)
        {
            Look();
        }

        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        // Check if Raycast hit anything with Interactable tag
        if (Physics.Raycast(ray, out hit, rayRange) && hit.collider.tag == "Interactable")
        {
            // Check if looking at the fireplace
            if (hit.transform.gameObject.TryGetComponent(out Fireplace fireplace))
            {
                if (Inventory.instance.wood >= 1)
                {
                    TextManager.instance.GiveInstruction("Press F to add wood");
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        fireplace.Addwood();
                    }
                }
                else
                {
                    TextManager.instance.HideInstructions();
                }
            }
            // Check if looking at firefood
            else if (hit.transform.gameObject.TryGetComponent(out Firewood firewood))
            {
                TextManager.instance.GiveInstruction("Press F to pickup");

                if (Input.GetKeyDown(KeyCode.F))
                {
                    TextManager.instance.HideInstructions();
                    firewood.PickUp();
                }
            }
            // Check if looking at woodholder / woodrack
            else if (hit.transform.gameObject.TryGetComponent(out WoodHolder woodHolder))
            {
                TextManager.instance.GiveInstruction("Press E to take and F to place");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    woodHolder.TakeWood();
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    woodHolder.PlaceWood();
                }
            }
            // Check if looking at the table
            else if (hit.transform.gameObject.TryGetComponent(out TaskManager taskmanager))
            {
                TextManager.instance.GiveInstruction("Press F to sit at the table");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    taskmanager.AtTheTable();
                    TextManager.instance.HideInstructions();
                }
            }
            // Check if looking at the door
            else if (hit.transform.gameObject.TryGetComponent(out Door door))
            {
                TextManager.instance.GiveInstruction("Press F to open and close");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    door.DoorActivate();
                }
            }
            // Check if looking at the christmastree
            else if (hit.transform.gameObject.TryGetComponent(out ChristmasTree christmasTree))
            {
                if (Inventory.instance.present >= 1)
                {
                    TextManager.instance.GiveInstruction("Press F to place a present");
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        christmasTree.placePresent();
                    }
                }
                else
                {
                    TextManager.instance.HideInstructions();
                }
            }
        }
        else
        {
            TextManager.instance.HideInstructions();
        }
    }

    /// <summary>
    /// Allows player to look
    /// </summary>
    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Counts the change
        xRotation -= mouseY;
        // Limits the change
        xRotation = Mathf.Clamp(xRotation, -80f, 70f);
        // Applyes the change
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void disableLook()
    {
        ableToLook = false;
    }
    public void activateLook()
    {
        ableToLook = true;
    }
}
