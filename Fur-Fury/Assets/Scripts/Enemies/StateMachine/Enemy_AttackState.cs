using UnityEngine;

public class Enemy_AttackState : Enemy_BaseState
{
    private float cooldownAttack;
    private float timer;

    private Berco_Life bercoLife;
    private Animator animator;

    public override void EnterState(Enemy_StateManager enemy)
    {
        animator = enemy.Animator;

        cooldownAttack = enemy.CooldownAttack;
        bercoLife = enemy.BercoLife;

        animator.SetBool("Attacking", true);
        Debug.Log("Estado Atacando");
    }

    public override void OnTriggerEnter(Enemy_StateManager enemy, Collider collision)
    {
        GameObject other = collision.gameObject;

        if (other != null)
        {
            if (other.TryGetComponent(out Damage_Shot bullet))
            {
                enemy.SwitchState(enemy.stunState);
            }
        }
    }

    public override void UpdateState(Enemy_StateManager enemy)
    {
        timer += Time.fixedDeltaTime;

        if(timer > cooldownAttack)
        {
            bercoLife.TakeDamage();
            timer = 0;
        }
    }
}
