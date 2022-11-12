using System.Collections;
using System.Threading;
using UnityEngine;

public class Enemy_StunState : Enemy_BaseState
{
    private Animator animator;

    private float timeToStun;
    private float timer;

    public override void EnterState(Enemy_StateManager enemy)
    {
        timer = 0;
        timeToStun = enemy.TimeStun;

        animator = enemy.Animator;
        animator.SetBool("Stun", true);
    }

    public override void OnTriggerEnter(Enemy_StateManager enemy, Collider collision)
    {
    }

    public override void UpdateState(Enemy_StateManager enemy)
    {
        timer += Time.fixedDeltaTime;

        if(timer >= timeToStun)
        {
            animator.SetBool("Stun", false);
            enemy.SwitchState(enemy.followState);
        }
    }
}
