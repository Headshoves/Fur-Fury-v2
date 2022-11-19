using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DieState : Enemy_BaseState
{
    private AudioSource audiosrc;

    private float timer;
    private float cooldownDie = 2f;
    public override void EnterState(Enemy_StateManager enemy)
    {
        Enemy_Spawn._singleton.KillEnemy();
        Debug.Log("Estado Morte");
        timer = 0;
        audiosrc = enemy.AudioSource;
        audiosrc.clip = enemy.AudioClips[5];
        audiosrc.Play();

    }

    public override void OnTriggerEnter(Enemy_StateManager enemy, Collider collision)
    {
    }

    public override void UpdateState(Enemy_StateManager enemy)
    {
        timer += Time.fixedDeltaTime;

        if (timer >= cooldownDie)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
