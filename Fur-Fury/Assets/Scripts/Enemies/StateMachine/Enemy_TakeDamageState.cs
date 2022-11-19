using UnityEngine;
using UnityEngine.AI;


public class Enemy_TakeDamageState : Enemy_BaseState
{
    private Transform player;
    private Rigidbody rb;


    private float radius = 100f;
    private float power = 1000f;

    private float timer;
    private float cooldownDamage = 6f;

    private AudioSource audiosrc;

    public override void EnterState(Enemy_StateManager enemy)
    {
        player = enemy.Player;
        rb = enemy.Rigidbody;

        enemy.isStuned = false;

        enemy.Life --;

        timer = 0;

        Vector3 tempPos = new Vector3(player.position.x, player.position.y - 1f, player.position.z);

        rb.AddExplosionForce(power, tempPos, radius, 3f);

        Debug.Log("Estado Tomando Dano, Vida: " + enemy.Life);
    }

    public override void OnTriggerEnter(Enemy_StateManager enemy, Collider collision)
    {

    }

    public override void UpdateState(Enemy_StateManager enemy)
    {
        timer += Time.fixedDeltaTime;


        if (timer >= cooldownDamage)
        {
            if(enemy.Life <= 0)
            {
                rb.isKinematic = true;
                rb.isKinematic = false;
                enemy.SwitchState(enemy.dieState);
  
            }
            else
            {
                rb.isKinematic = true;
                rb.isKinematic = false;
                enemy.SwitchState(enemy.followState);
            }
            
        }
    }
}
