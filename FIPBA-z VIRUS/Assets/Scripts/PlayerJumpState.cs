using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isJump", true);
        animator.SetBool("isRunning", false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        bool isJumping = Input.GetButtonDown("Jump");

        // Animasi Lari
        if (moveHorizontal != 0f || moveVertical != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Lompat di tempat
        if (isJumping)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }

        // Lari sambil Lompat
        if (isJumping && moveHorizontal != 0f && moveVertical != 0f)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isJump", false);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0f || moveVertical != 0f)
        {
            animator.SetBool("isRunning", true);
        }
    }
}
