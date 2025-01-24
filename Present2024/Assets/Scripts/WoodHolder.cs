using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodHolder : MonoBehaviour
{
    [SerializeField] int holdingWood = 0;
    [SerializeField] int woodLimit = 5;
    [SerializeField] TextMeshProUGUI amountHolding;

    [Header("Woods")]
    [SerializeField] GameObject wood1;
    [SerializeField] GameObject wood2;
    [SerializeField] GameObject wood3;
    [SerializeField] GameObject wood4;
    [SerializeField] GameObject wood5;

    private void Start()
    {
        UpdateText();
    }

    /// <summary>
    /// Takes 1 wood from inventory to the rack
    /// </summary>
    public void PlaceWood() // In woodrack
    {
        if (holdingWood < woodLimit && Inventory.instance.wood > 0)
        {
            Inventory.instance.PlaceWood();
            holdingWood++;
            UpdateText();
        }
        else
        {
            if (Inventory.instance.wood <= 0)
            {
                TextManager.instance.DisplayLines("I'm out of wood", true);
            }
            else if (holdingWood >= woodLimit)
            {
                TextManager.instance.DisplayLines("The rack is full.", true);
            }
        }
    }

    /// <summary>
    /// Takes 1 wood from the rack to invnetory
    /// </summary>
    public void TakeWood() // Out woodrack
    {
        if (holdingWood > 0 && Inventory.instance.PickWood())
        {
            holdingWood--;
            UpdateText();
        }
        else
        {
            if (holdingWood <= 0 && Inventory.instance.wood > 0)
            {
                TextManager.instance.DisplayLines("The rack is empty.", true);                
            }
        }
    }

    /// <summary>
    /// Updates the AmountHolding text and places wood in the rack
    /// </summary>
    void UpdateText()
    {
        amountHolding.text = holdingWood.ToString();

        if (holdingWood == 0)
        {
            wood1.SetActive(false);
            wood2.SetActive(false);
            wood3.SetActive(false);
            wood4.SetActive(false);
            wood5.SetActive(false);
        }
        else if (holdingWood == 1)
        {
            wood1.SetActive(true);

            wood2.SetActive(false);
            wood3.SetActive(false);
            wood4.SetActive(false);
            wood5.SetActive(false);
        }
        else if (holdingWood == 2)
        {
            wood1.SetActive(true);
            wood2.SetActive(true);

            wood3.SetActive(false);
            wood4.SetActive(false);
            wood5.SetActive(false);
        }
        else if (holdingWood == 3)
        {
            wood1.SetActive(true);
            wood2.SetActive(true);
            wood3.SetActive(true);

            wood4.SetActive(false);
            wood5.SetActive(false);
        }
        else if (holdingWood == 4)
        {
            wood1.SetActive(true);
            wood2.SetActive(true);
            wood3.SetActive(true);
            wood4.SetActive(true);

            wood5.SetActive(false);
        }
        else if (holdingWood == 5)
        {
            wood1.SetActive(true);
            wood2.SetActive(true);
            wood3.SetActive(true);
            wood4.SetActive(true);
            wood5.SetActive(true);
        }
    }
}
