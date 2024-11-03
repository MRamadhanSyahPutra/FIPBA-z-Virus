using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolRunState : StateMachineBehaviour
{
    private float moveThreshold = 0.9f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isGunIdle", false);
        animator.SetBool("isPistolGun", true);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");

        // Aktifkan Running hanya jika input gerakan melampaui ambang batas
        if (Mathf.Abs(moveHorizontal) > moveThreshold || Mathf.Abs(moveVertical) > moveThreshold)
        {
            animator.SetBool("isPistolGun", true);
        }
        else
        {
            animator.SetBool("isPistolGun", false);
        }

        // Cek kondisi lompat
        // if (isJumping)
        // {
        //     animator.SetBool("isJump", true);
        // }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPistolGun", false);
    }
}
