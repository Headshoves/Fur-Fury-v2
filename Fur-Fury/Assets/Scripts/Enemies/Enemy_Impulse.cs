using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Impulse : MonoBehaviour
{
   // public GameObject enemy;
    public float forceApplied = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            Debug.Log("collision");
        }
    }

}
