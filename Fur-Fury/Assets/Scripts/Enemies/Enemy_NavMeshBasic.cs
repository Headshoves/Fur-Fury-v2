using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy_NavMeshBasic : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float coolDownToFollow = 1f;
    [SerializeField] private int _enemyDamage = 1;
    
    private NavMeshAgent _nma;
    private Collider _coll;
    private Transform _player;
    private Transform _baby;

    private Enemy_Stuned _enemyStuned;

    public Animator anim;



    [Header("To attack the crib")]
    [SerializeField] private float _enemyBabyRange = 3f;
    [SerializeField] private float cooldownAttack = 2f;

    private float _babyDistance;
    private bool _enemyInRange;


    void OnEnable()
    {
        _nma = GetComponent<NavMeshAgent>();
        _coll = GetComponent<Collider>();
        _baby = GameObject.Find("Berco").transform;
        _player = GameObject.Find("Player").transform;

        _enemyStuned = GetComponent<Enemy_Stuned>();
    }

    private void Update()
    {
        _babyDistance = Vector3.Distance(this.transform.position, _baby.position);
        
        if (_babyDistance <= _enemyBabyRange)
        {
            _nma.isStopped = true;
            _enemyInRange = true;
            StartCoroutine("EnemyAttackBaby");
        }

        if (!_enemyInRange)
        {
            StopCoroutine("EnemyAttackBaby");
            anim.SetBool("Attacking", false);
            if (!_enemyStuned.IsStuned)
            {
                _nma.isStopped = false;
                if (_coll.enabled && _player.gameObject.activeSelf && _baby.gameObject.activeSelf)
                    _nma.SetDestination(_baby.position);
            }
            else
            {
                _nma.isStopped = true;
            }
        }
        else
        {

            anim.SetBool("Attacking", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_enemyStuned.IsStuned)
        {
            StartCoroutine(Hit());
        }
    }

    private IEnumerator Hit()
    {
        _player.gameObject.GetComponent<Player_Life>().TakeDamage(_enemyDamage);
        _nma.isStopped = true;
        yield return new WaitForSeconds(coolDownToFollow);
        _nma.isStopped = false;
    }

    private IEnumerator EnemyAttackBaby()
    {
        yield return new WaitForSeconds(cooldownAttack);
        if(this.gameObject.activeSelf && !_enemyStuned.IsStuned)
        {
            _baby.GetComponent<Berco_Life>().TakeDamage();
            StartCoroutine("EnemyAttackBaby");
        }
    }
}
