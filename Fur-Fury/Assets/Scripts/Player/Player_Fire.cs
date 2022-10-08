using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Fire : MonoBehaviour
{
    [Header("Shotgun Control")]
    [SerializeField] private float pelletFireVel = 1;
    [SerializeField] private GameObject pellet;
    [SerializeField] private Transform barrelExit;

    private Animator anim;

    [Header("Polling")]
    [SerializeField] private int shotsAmount = 20;
    private List<GameObject> bullets;

    [Header("Cadence")]
    [SerializeField] private float cadenceTime = 0.1f;
    private bool _canShot = true;


    private void Awake()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < shotsAmount; i++)
        {
            GameObject obj = Instantiate(pellet);
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }

    private void Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && _canShot)
        {
            Fire();
            StartCoroutine(Cadence());
        }
    }

    private void Fire()
    {
        GameObject temp = GetBullet();
        temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * pelletFireVel);
        anim.SetTrigger("Shot");
    }

    private GameObject GetBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = barrelExit.position;
                bullets[i].transform.rotation = barrelExit.rotation;
                bullets[i].SetActive(true);
                return bullets[i];
            }
        }
        return null;
    }

    private IEnumerator Cadence()
    {
        _canShot = false;
        yield return new WaitForSeconds(cadenceTime);
        _canShot = true;
    }
}
