using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour
{
    [Header("Shotgun Control")]
    [SerializeField] private float pelletFireVel = 1;
    [SerializeField] private GameObject pellet;
    [SerializeField] private Transform barrelExit;

    [Header("Polling")]
    [SerializeField] private int shotsAmount = 20;
    private List<GameObject> _bullets;

    [Header("Cadence")]
    [SerializeField] private float cadenceTime = 0.1f;
    private bool _canShot = true;

    //Components
    private Animator anim;

    private void Awake()
    {
        _bullets = new List<GameObject>();
        for (int i = 0; i < shotsAmount; i++)
        {
            GameObject obj = Instantiate(pellet);
            obj.SetActive(false);
            _bullets.Add(obj);
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
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_bullets[i].activeInHierarchy)
            {
                _bullets[i].transform.position = barrelExit.position;
                _bullets[i].transform.rotation = barrelExit.rotation;
                _bullets[i].SetActive(true);
                return _bullets[i];
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
