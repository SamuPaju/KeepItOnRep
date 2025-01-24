using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [Header("Inventory Loot")]
    public int wood;
    public int present;

    //[Header("Inventory Gear")]

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        GetInventory();
    }

    /// <summary>
    /// Prints inventory to console (At the moment)
    /// </summary>
    void GetInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            print("Wood: " + wood);
            print("Presents: " +  present);
        }
    }

    /// <summary>
    /// Adds 1 wood to inventory but if it goes over the limit it calls WoodOverLoad
    /// </summary>
    /// <returns></returns>
    public bool PickWood()
    {
        wood++;
        if (wood > 3)
        {
            StartCoroutine(WoodOverload());
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Removes 1 wood from inventory
    /// </summary>
    public void PlaceWood()
    {
        wood--;
    }

    /// <summary>
    /// Sets wood to max amount and tells player that he can't carry more wood
    /// </summary>
    /// <returns></returns>
    IEnumerator WoodOverload()
    {
        //print("Too much wood to carry");
        TextManager.instance.DisplayLines("Too much wood to carry", false);
        //woodOverloadUI.SetActive(true);
        wood = 3;
        yield return new WaitForSeconds(2.5f);
        //woodOverloadUI.SetActive(false);
        TextManager.instance.HideLines();
    }

    public void placePresent()
    {
        present--;
    }
}
