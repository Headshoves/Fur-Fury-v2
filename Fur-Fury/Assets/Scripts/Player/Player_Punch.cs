using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Punch : MonoBehaviour
{

    [SerializeField] private float radius;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float powerPunch;

    private void Start()
    {
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider[] hit = Physics.OverlapSphere(transform.position + offset, radius);

            for(int i = 0; i < hit.Length; i++)
            {
                if (hit[i].gameObject.TryGetComponent(out Enemy_NavMeshBasic enemy))
                    {
                    if (enemy.GetStuned())
                        {
                        enemy.Punch();
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
