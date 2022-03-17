using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : StateMachineBehaviour
{
    private Transform playerPosition;
    public float wanderSpeed;
    public float chaseDistanceStart;
    private Vector3 target;
    private float Distance;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        float x = Random.Range(-1, 2);
        float y = Random.Range(-1, 2);
        float walktime = Random.Range(1, 2);
        Distance = wanderSpeed * walktime;
        target = animator.transform.position + new Vector3(x, y, 0);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, Distance * Time.deltaTime);
        //animator.transform.position += new Vector3(x, y, 0);

        if (Vector2.Distance(playerPosition.position, animator.transform.position) <= chaseDistanceStart) 
       {
           animator.SetBool("isChasing", true);
       }

       if (animator.transform.position == target) {
           animator.SetBool("isWandering", false);
       }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.SetBool("isWandering", false);
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
