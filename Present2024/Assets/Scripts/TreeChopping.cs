using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChopping : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] GameObject firewood;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // If health goes to zero spawn random firewood and deletes the tree
        if (health <= 0)
        {
            firewood = GetRandomFirewood.instance.GetRandomWood();
            Instantiate(firewood, transform.position + new Vector3(0, 1, 0), firewood.transform.rotation);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Lowers trees health and activates Hit animation
    /// </summary>
    public void DecreaseHealth()
    {
        health--;
        animator.SetTrigger("HitTaken");
    }
}
