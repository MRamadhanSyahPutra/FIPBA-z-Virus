using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunIdleState : StateMachineBehaviour
{
    private float moveThreshold = 0.1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isGunIdle", true);
        animator.SetBool("isPistolGun", false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");

        if (InteractionManager.Instance.isHoldingWeapon)
        {
            animator.SetBool("isGunIdle", true);
            animator.SetBool("isIdle", false);

            Weapon currentWeapon = WeaponManager.Instance.GetCurrentWeapon();

            if (currentWeapon != null)
            {

                animator.SetBool("isGunIdle", true);
                animator.SetBool("isIdle", false);

                if (currentWeapon.thisWeaponModel == Weapon.WeaponModel.Pistol)
                {
                    // Ketika berjalan
                    if (Mathf.Abs(moveHorizontal) > moveThreshold || Mathf.Abs(moveVertical) > moveThreshold)
                    {
                        animator.SetBool("isPistolGun", true);
                    }
                }
                else if (currentWeapon.thisWeaponModel == Weapon.WeaponModel.Ak47)
                {
                    // Ketika berjalan
                    if (Mathf.Abs(moveHorizontal) > moveThreshold || Mathf.Abs(moveVertical) > moveThreshold)
                    {
                        animator.SetBool("isAk47Gun", true);
                    }
                }
            }
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
