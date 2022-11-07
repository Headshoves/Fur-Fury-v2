using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Life : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private AudioClip clip;

    private Enemy_Stuned enemyStuned;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        enemyStuned = GetComponent<Enemy_Stuned>();
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        enemyStuned.IsStuned = false;
        if (life<=0)
        {
            Enemy_Spawn._singleton.KillEnemy();
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if(clip != null)
        {
            source.clip = clip;
            source.Play();
        }
    }
}
