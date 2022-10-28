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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider[] hit = Physics.OverlapSphere(transform.position + offset, radius);

            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].gameObject.TryGetComponent(out Enemy_Stuned enemy))
                    {
                    if (enemy.IsStuned)
                        enemy.Punch();
                    anim.SetTrigger("Kick");
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
