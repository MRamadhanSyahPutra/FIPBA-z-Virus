using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47RunState : StateMachineBehaviour
{
    private float moveThreshold = 0.9f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isGunIdle", false);
        animator.SetBool("isAk47Gun", true);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");

        // Aktifkan Running hanya jika input gerakan melampaui ambang batas
        if (Mathf.Abs(moveHorizontal) > moveThreshold || Mathf.Abs(moveVertical) > moveThreshold)
        {
            animator.SetBool("isAk47Gun", true);
        }
        else
        {
            animator.SetBool("isAk47Gun", false);
        }

        // Cek kondisi lompat
        // if (isJumping)
        // {
        //     animator.SetBool("isJump", true);
        // }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAk47Gun", false);
    }
}
