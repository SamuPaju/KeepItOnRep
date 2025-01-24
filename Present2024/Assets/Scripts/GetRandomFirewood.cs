using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomFirewood : MonoBehaviour
{
    public static GetRandomFirewood instance;
    public GameObject[] firewoods;
    int firewood;

    void Start()
    {
        instance = this;
    }

    /// <summary>
    /// Gives a random firewood prefab
    /// </summary>
    /// <returns>Firewood prefab</returns>
    public GameObject GetRandomWood()
    {
        firewood = Random.Range(0, firewoods.Length);
        return firewoods[firewood];
    }
}
