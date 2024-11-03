using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47AssetRunningState : StateMachineBehaviour
{
    private float moveThreshold = 0.1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAk47Run", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(moveHorizontal) > moveThreshold || Mathf.Abs(moveVertical) > moveThreshold)
        {
            animator.SetBool("isAk47Run", true);
        }
        else
        {
            animator.SetBool("isAk47Run", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAk47Run", false);
    }
}
