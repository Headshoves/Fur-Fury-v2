using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Shot : Damage_General
{
    //General
    [SerializeField] private int damageValue;
    [SerializeField] private float lifeTime = 0.5f;

    //Components
    private Rigidbody _rb;
    
    private void OnEnable()
    {
        Damage = damageValue;
        Invoke("DisableShot", lifeTime);
        _rb = GetComponent<Rigidbody>();
        canDamage = true;
    }

    private void DisableShot()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _rb.isKinematic = true;
        _rb.isKinematic = false;
        _rb.useGravity = false;
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Scenario"))
        {
            canDamage = false;
            _rb.useGravity = true;
        }
    }
}
