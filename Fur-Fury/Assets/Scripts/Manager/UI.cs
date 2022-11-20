using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{


    private float timer;
    private float cooldownPrepare = 7;
    private float cooldownKeys = 30;
    private float cooldownDica1 = 20;
    private float cooldownDica2 = 40;

    public GameObject Prepare;
    public GameObject Keys;
    public GameObject dica1;
    public GameObject dica2;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= cooldownPrepare)
        {
            Prepare.SetActive(false);
            dica1.SetActive(true);
        }

        if (timer >= cooldownKeys)
        {
            Keys.SetActive(false);
        }

        if (timer >= cooldownDica1)
        {
            dica1.SetActive(false);
            dica2.SetActive(true);
        }

        if (timer >= cooldownDica2)
        {
            dica2.SetActive(false);
        }


    }

}

