using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Punch : MonoBehaviour
{
    //General
    [SerializeField] private float radius;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float powerPunch;

    [SerializeField] private Animator anim;

    public AudioSource _audiosrc;
    private AudioClip kick;
    public AudioClip[] kickArray;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider[] hit = Physics.OverlapSphere(transform.position + offset, radius);
            int index = Random.Range(0, kickArray.Length - 1);
               kick = kickArray[index];
               _audiosrc.clip = kick;
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].gameObject.TryGetComponent(out Enemy_StateManager enemy))
                    {
                    if (enemy.isStuned)
                    {
                        anim.SetTrigger("Kick");
                        enemy.SwitchState(enemy.takeDamageState);
                        _audiosrc.Play();
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
