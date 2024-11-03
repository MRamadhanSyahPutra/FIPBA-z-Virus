using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKondisiState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isGunIdle", false);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Cek apakah player sedang memegang senjata atau tidak
        if (InteractionManager.Instance.isHoldingWeapon)
        {
            animator.SetBool("isGunIdle", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isGunIdle", false);
            animator.SetBool("isIdle", true);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isGunIdle", false);
        animator.SetBool("isIdle", true);
    }
}
