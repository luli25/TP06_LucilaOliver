using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_follow : StateMachineBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private float time;

    private float followTime;
    private Transform player;
    private Bat bat;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        followTime = time;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bat = animator.gameObject.GetComponent<Bat>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, enemyData.speed * Time.deltaTime);
        bat.Turn(player.position);
        followTime -= Time.deltaTime;
        if(followTime <= 0)
        {
            animator.SetTrigger("Return");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
