using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolRecoil : StateMachineBehaviour
{
    private float moveThreshold = 0.1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(moveHorizontal) > moveThreshold || Mathf.Abs(moveVertical) > moveThreshold)
        {
            animator.SetBool("isPistolRun", true);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
