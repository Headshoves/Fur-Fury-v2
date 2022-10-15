using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Punch : MonoBehaviour
{

    [SerializeField] private float radius;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float powerPunch;

    private Transform berco;

    private void Start()
    {
        berco = GameObject.FindGameObjectWithTag("Baby").transform;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Collider[] hit = Physics.OverlapSphere(transform.position + offset, radius);

            for(int i = 0; i < hit.Length; i++)
            {
                if (hit[i].gameObject.TryGetComponent(out Enemy_NavMeshBasic enemy))
                    {
                    if (enemy.GetStuned())
                        {
                            enemy.gameObject.GetComponent<Rigidbody>().AddForce(enemy.transform.position - berco.transform.position * powerPunch, ForceMode.Impulse);
                        print("hitou");
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
