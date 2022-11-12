using UnityEngine;
using UnityEngine.AI;

public class Enemy_FollowState : Enemy_BaseState
{
    private NavMeshAgent nma;
    private Transform berco;

    private float enemyBabyRange = 3f;

    private float babyDistance;

    public override void EnterState(Enemy_StateManager enemy)
    {
        nma = enemy.NMA;
        berco = enemy.Berco;
    }

    public override void OnTriggerEnter(Enemy_StateManager enemy, Collider collision)
    {
        GameObject other = collision.gameObject;

        if (other != null)
        {
            if (other.TryGetComponent(out Damage_Shot bullet))
            {
                nma.isStopped = true;
                enemy.SwitchState(enemy.stunState);
            }
        }
    }

    public override void UpdateState(Enemy_StateManager enemy)
    {
        babyDistance = Vector3.Distance(enemy.transform.position, berco.position);

        if(babyDistance <= enemyBabyRange)
        {
            enemy.SwitchState(enemy.attackState);
        }
        else
        {
            nma.isStopped = false;
            nma.SetDestination(berco.position);
        }
    }
}