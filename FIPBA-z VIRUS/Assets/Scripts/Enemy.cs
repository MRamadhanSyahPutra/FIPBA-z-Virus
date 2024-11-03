using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private Animator animator;
    private NavMeshAgent navAgent;
    public bool isDead;
    public CapsuleCollider capsuleCollider;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int demageAmount)
    {
        HP -= demageAmount;
        if (HP <= 0)
        {
            isDead = true;

            int randomValue = Random.Range(0, 2);
            if (randomValue == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {

                animator.SetTrigger("DIE2");
            }

            if (capsuleCollider != null)
            {
                capsuleCollider.enabled = false;
            }

            //Dead Sound
            SoundManager.Instance.zombieChannel2.PlayOneShot(SoundManager.Instance.zombieDeath);
        }
        else
        {
            animator.SetTrigger("DAMAGE");

            //Hurt Sound
            SoundManager.Instance.zombieChannel2.PlayOneShot(SoundManager.Instance.zombieHurt);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f); //Menyerang // Berhenti menyerang 

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 100f); //jangkauan di kejar    -default nya 18f-

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 101f); //Berhenti mengejar     -default ny 21f-
    }

}
