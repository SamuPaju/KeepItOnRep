using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    Animator animator;
    public bool active = true;
    BoxCollider boxCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        Hit();
        boxCollider.enabled = !active;
    }

    /// <summary>
    /// Activate hit animation
    /// </summary>
    void Hit()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && active)
        {
            animator.SetTrigger("Hit");
            active = false;
        }
    }

    /// <summary>
    /// Set hitting animation off
    /// </summary>
    public void SetBack()
    {
        active = true;
    }

    /// <summary>
    /// Checking if the axe hitted something important
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TreeChopping treeChopping))
        {
            treeChopping.DecreaseHealth();
        }
    }
}
