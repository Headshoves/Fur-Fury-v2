using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy_NavMeshBasic : MonoBehaviour
{
    [SerializeField] private float coolDownToFollow = 1f;
    [SerializeField] private int _enemyDamage = 1;
    [SerializeField] private float powerPunch = 2f;
    
    private NavMeshAgent _nma;
    private Rigidbody _rigidbody;
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
        _rigidbody = GetComponent<Rigidbody>();
        _baby = GameObject.Find("Berco").transform;
        _player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        if(!isStuned)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isStuned)
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
                bullet.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator Hit()
    {
        _player.gameObject.GetComponent<Player_Life>().TakeDamage(_enemyDamage);
        _nma.isStopped = true;
        yield return new WaitForSeconds(coolDownToFollow);
        _nma.isStopped = false;
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

    public void SetStuned(bool stuned) { isStuned = stuned; }

    public void Punch()
    {
        StartCoroutine("IEPunch");
    }

    private IEnumerator IEPunch()
    {
        Stuned();
        _nma.acceleration = 0;
        _nma.speed = 0;
        enemyLife.TakeDamage(1);
        _rigidbody.AddForce((transform.position - _player.transform.position).normalized * powerPunch, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        _rigidbody.isKinematic = true;
        isStuned = false;
        yield return new WaitForSeconds(0.1f);
        _rigidbody.isKinematic = false;
        _nma.acceleration = 3.5f;
        _nma.speed = 8f;
    }
}
