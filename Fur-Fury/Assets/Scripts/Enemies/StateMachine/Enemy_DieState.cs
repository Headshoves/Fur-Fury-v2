using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DieState : Enemy_BaseState
{
    public override void EnterState(Enemy_StateManager enemy)
    {
        Enemy_Spawn._singleton.KillEnemy();
        enemy.gameObject.SetActive(false);
        Debug.Log("Estado Morte");
    }

    public override void OnTriggerEnter(Enemy_StateManager enemy, Collider collision)
    {
    }

    public override void UpdateState(Enemy_StateManager enemy)
    {
    }
}
