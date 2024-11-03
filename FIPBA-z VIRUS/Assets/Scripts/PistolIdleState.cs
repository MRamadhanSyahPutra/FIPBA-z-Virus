using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolIdleState : StateMachineBehaviour
{
    private float moveThreshold = 0.1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPistolIdle", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");

        if (InteractionManager.Instance.isHoldingWeapon)
        {
            animator.SetBool("isPistolIdle", true);
            Weapon currentWeapon = WeaponManager.Instance.GetCurrentWeapon();

            if (currentWeapon != null)
            {
                animator.SetBool("isPistolIdle", true);
                if (currentWeapon.thisWeaponModel == Weapon.WeaponModel.Pistol)
                {
                    // Ketika berjalan
                    if (Mathf.Abs(moveHorizontal) > moveThreshold || Mathf.Abs(moveVertical) > moveThreshold)
                    {
                        animator.SetBool("isPistolRun", true);
                    }
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPistolIdle", false);
    }

}
