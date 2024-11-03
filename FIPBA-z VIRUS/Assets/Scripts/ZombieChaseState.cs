using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float chaseSpeed = 6f;
    public float StopChasingDistance = 21;
    public float attackingDistance = 1.5f;
    public float runningRange = 10f;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //-- Initialization --//
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = chaseSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (SoundManager.Instance.zombieChannel1.isPlaying == false)
        {
            SoundManager.Instance.zombieChannel1.PlayOneShot(SoundManager.Instance.zombieChese);
        }

        agent.SetDestination(player.position);
        animator.transform.LookAt(player);

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);

        //Jika agent di haruskan berhenti mengejar
        if (distanceFromPlayer > StopChasingDistance)
        {
            animator.SetBool("isChasing", false);
        }

        //Jika agent menyerang
        if (runningRange > distanceFromPlayer)
        {
            if (distanceFromPlayer > attackingDistance)
            {
                animator.SetBool("isAttacking", true);
            }
        }
        else
        {
            animator.SetBool("isAttacking", false); // Reset animasi serangan
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);

        SoundManager.Instance.zombieChannel1.Stop();
    }
}
