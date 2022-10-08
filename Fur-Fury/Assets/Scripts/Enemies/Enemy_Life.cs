using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Life : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private AudioClip clip;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life<=0)
        {
            this.gameObject.SetActive(false);
            Enemy_Spawn._singleton.KillEnemy();
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
