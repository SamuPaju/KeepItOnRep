using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareManager : MonoBehaviour
{
    public static ScareManager instance;

    [Header("Base Variables")]
    [SerializeField] TaskCamera taskCamera;
    [SerializeField] TaskManager taskManager;

    [Header("Scare 1")]
    [SerializeField] GameObject treeDemon;
    bool done1 = false;


    [Header("Scare 2")]
    [SerializeField] AudioSource doorKnocking;
    bool done2 = false;


    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        Scare1();
        Scare2();
    }

    /// <summary>
    /// activate the demon jumpscare after third present is wrapped
    /// </summary>
    void Scare1()
    {
        if (!done1)
        {
            if (taskCamera.currentPresents >= 3)
            {
                treeDemon.SetActive(true);
                if (taskManager.atTable == false || taskCamera.lookingUp == true)
                {
                    StartCoroutine(HideDemon());                    
                }
            }
        }
    }

    /// <summary>
    /// Hide the demon after a little wait and the scare complete
    /// </summary>
    /// <returns></returns>
    IEnumerator HideDemon()
    {
        yield return new WaitForSeconds(3);
        treeDemon.SetActive(false);
        done1 = true;
    }

    /// <summary>
    /// Activate the sound jumpscare while wrapping second gift
    /// </summary>
    void Scare2()
    {
        if (!done2)
        {
            if (taskCamera.currentPresents >= 1 && taskCamera.currentTime >= taskCamera.wrapTime * 0.65f)
            {
                doorKnocking.Play();
                done2 = true;
            }
        }
    }
}
