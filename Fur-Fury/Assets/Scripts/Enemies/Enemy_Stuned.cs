using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy_Stuned : MonoBehaviour
{
    [SerializeField] private float timeToStun = 5f;
    [SerializeField] private float powerPunch = 20f;

    //Components
    private NavMeshAgent _nma;
    private Rigidbody _rigidbody;
    private Transform _player;
    private Enemy_Life enemyLife;



    public Animator anim;
    private bool _isStuned;
    public bool IsStuned { 
        get { return _isStuned; }
        set { _isStuned = value; }
    }

    private void Start()
    {
        _nma = GetComponent<NavMeshAgent>();
        enemyLife = GetComponent<Enemy_Life>();
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent(out Damage_Shot bullet))
        {
            if (bullet.GetCanDamage())
            {
                print("entrou aqui");
                StartCoroutine("Stuned");
                other.gameObject.SetActive(false);

                
            }
        }
    }

    private IEnumerator Stuned()
    {
        if (!_isStuned)
        {
            _isStuned = true;
            anim.SetBool("Stun", true);
            yield return new WaitForSeconds(timeToStun);
            _isStuned = false;
            anim.SetBool("Stun", false);
        }
    }

    public void Punch()
    {
        StartCoroutine("IEPunch");
        anim.SetTrigger("Kick");
    }

    private IEnumerator IEPunch()
    {
        _nma.acceleration = 0;
        _nma.speed = 0;
        enemyLife.TakeDamage(1);
        _rigidbody.AddForce((transform.position - _player.transform.position).normalized * powerPunch, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        _rigidbody.isKinematic = true;
        _isStuned = true;
        yield return new WaitForSeconds(0.1f);
        _rigidbody.isKinematic = false;
        _nma.acceleration = 0.5f;
        _nma.speed = 1f;
    }
}
