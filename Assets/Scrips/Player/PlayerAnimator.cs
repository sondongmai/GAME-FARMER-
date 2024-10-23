using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private Animator animator;

    [Header("Setting")]
    [SerializeField] private float moveSpeedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManageAnimations(Vector3 moveVector)
    {
        if(moveVector.magnitude > 0) {  
        
            animator.SetFloat("moveSpeed",moveVector.magnitude* moveSpeedMultiplier);
            PlayerRunAnimation();
            animator.transform.forward = moveVector.normalized;
        }
        else
        {
            PlayerIdeAnimation();
        }   
        
    }
    private void PlayerIdeAnimation()
    {
        animator.Play("Ide");
    }

    private void PlayerRunAnimation()
    {
        animator.Play("Run");
    }
}
