using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47IdleState : StateMachineBehaviour
{
    private float moveThreshold = 0.1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAk47Idle", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");

        if (InteractionManager.Instance.isHoldingWeapon)
        {
            animator.SetBool("isAk47Idle", true);
            Weapon currentWeapon = WeaponManager.Instance.GetCurrentWeapon();

            if (currentWeapon != null)
            {
                animator.SetBool("isAk47Idle", true);
                if (currentWeapon.thisWeaponModel == Weapon.WeaponModel.Ak47)
                {
                    // Ketika berjalan
                    if (Mathf.Abs(moveHorizontal) > moveThreshold || Mathf.Abs(moveVertical) > moveThreshold)
                    {
                        animator.SetBool("isAk47Run", true);
                    }
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAk47Idle", false);
    }
}
