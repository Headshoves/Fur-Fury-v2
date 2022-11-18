using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy_TakeDamageState : Enemy_BaseState
{
    private int life;
    private Transform player;
    private Rigidbody rb;
    private NavMeshAgent nma;
    private Transform thisTransform;


    public override void EnterState(Enemy_StateManager enemy)
    {
        player = enemy.Player;
        rb = enemy.Rigidbody;
        nma = enemy.NMA;
        thisTransform = enemy.transform;


        life = enemy.Life;
        enemy.Life --;

        if(life <= 0)
        {
            enemy.SwitchState(enemy.dieState);
        }
        else
        {
            /*nma.acceleration = 0;
            nma.speed = 0;
            rb.AddForce((thisTransform.position - player.transform.position).normalized * powerPunch, ForceMode.Impulse);
            yield return new WaitForSeconds(1f);
            rb.isKinematic = true;
            yield return new WaitForSeconds(0.1f);
            rb.isKinematic = false;
            nma.acceleration = 0.5f;
            nma.speed = 1f;*/
        }
        Debug.Log("Estado Tomando Dano");
    }

    public override void OnTriggerEnter(Enemy_StateManager enemy, Collider collision)
    {
    }

    public override void UpdateState(Enemy_StateManager enemy)
    {
    }
}
