using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewood : MonoBehaviour
{
    /// <summary>
    /// Adds 1 wood to inventory if there is space
    /// </summary>
    public void PickUp()
    {
        if (Inventory.instance.PickWood())
        {
            Destroy(gameObject);
        }
    }
}
