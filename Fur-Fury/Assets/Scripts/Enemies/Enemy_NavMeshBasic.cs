using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavMeshBasic : MonoBehaviour
{
    [SerializeField] private float coolDownToFollow = 1f;
    [SerializeField] private int _enemyDamage = 1;
    
    private NavMeshAgent _nma;
    private Collider _coll;
    private Transform _player;
    private Transform _baby;

    private bool isStuned;
    [SerializeField] private float timeStun;

    private Enemy_Life enemyLife;
    void OnEnable()
    {
        _nma = GetComponent<NavMeshAgent>();
        _coll = GetComponent<Collider>();
        enemyLife = GetComponent<Enemy_Life>();
        _baby = GameObject.Find("Berco").transform;
        _player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        if(!isStuned)
        {
            if (_coll.enabled && _player.gameObject.activeSelf && _baby.gameObject.activeSelf)
                _nma.SetDestination(_baby.position);
        }
        else
        {
            _nma.Stop();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Hit());
        }

        if (other.CompareTag("Baby"))
        {
            this.gameObject.SetActive(false);
            other.gameObject.GetComponent<Berco_Life>().TakeDamage();
            enemyLife.TakeDamage(9999);
        }

        if (other.gameObject.TryGetComponent(out Damage_Shot bullet))
        {
            if (bullet.GetCanDamage())
            {
                StartCoroutine("Stuned");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Hit());
        }

        if (collision.gameObject.CompareTag("Baby"))
        {
            this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<Berco_Life>().TakeDamage();
            enemyLife.TakeDamage(9999);
        }

        if (collision.gameObject.TryGetComponent(out Damage_Shot bullet))
        {
            if(bullet.GetCanDamage())
            {
                StartCoroutine("Stuned");
            }
        }
    }

    private IEnumerator Hit()
    {
        _player.gameObject.GetComponent<Player_Life>().TakeDamage(_enemyDamage);
        //_coll.enabled = false;
        _nma.isStopped = true;
        yield return new WaitForSeconds(coolDownToFollow);
        _nma.isStopped = false;
       //_coll.enabled = true; 
    }

    private IEnumerator Stuned()
    {   if(!isStuned)
        {
            isStuned = true;
            yield return new WaitForSeconds(timeStun);
            isStuned = false;
        }
    }

    public bool GetStuned()
    {
        return isStuned;
    }


}
