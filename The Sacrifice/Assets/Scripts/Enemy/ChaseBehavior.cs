using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehavior : StateMachineBehaviour
{
    private Transform playerPosition;
    //public Transform enemy;
    public float chaseDistanceGiveUp;
    public float attackRange;
    public float speed;
    private Vector2 direction;
    //public SpriteRenderer sprite;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      if (Vector2.Distance(playerPosition.position, animator.transform.position) >= attackRange-1) {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPosition.position, speed * Time.deltaTime);
        direction = (playerPosition.position - animator.transform.position).normalized;
        if (direction.x < 0) {
            animator.transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            animator.transform.localScale = new Vector3(1, 1, 1);
        }
      }

        if (Vector2.Distance(playerPosition.position, animator.transform.position) > chaseDistanceGiveUp) 
       {
           animator.SetBool("isChasing", false);
       }
        if (Vector2.Distance(playerPosition.position, animator.transform.position) <= attackRange) 
       {
           animator.SetTrigger("TriggerAttack");
       }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.SetBool("isChasing", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
