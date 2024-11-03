using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : StateMachineBehaviour
{
    private float moveThreshold = 0.1f;  // Ambang batas untuk deteksi gerakan

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset semua kondisi ketika memasuki state Idle
        animator.SetBool("isIdle", true);
        animator.SetBool("isRunning", false);
        animator.SetBool("isJump", false);
        animator.SetBool("isGunIdle", false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");

        // Hanya aktifkan animasi running jika input melebihi ambang batas
        if (Mathf.Abs(moveHorizontal) > moveThreshold || Mathf.Abs(moveVertical) > moveThreshold)
        {
            animator.SetBool("isRunning", true);
        }

        // Cek kondisi lompat
        if (isJumping)
        {
            animator.SetBool("isJump", true);
        }
        if (InteractionManager.Instance.isHoldingWeapon)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isGunIdle", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isIdle", false);
    }
}
