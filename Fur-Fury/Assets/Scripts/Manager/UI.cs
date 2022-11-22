using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField] private float cooldownPrepare = 2;
    [SerializeField] private float cooldownKeys = 30;
    [SerializeField] private float cooldownDica1 = 20;
    [SerializeField] private float cooldownDica2 = 40;

    public GameObject Prepare;
    public GameObject Keys;
    public GameObject dica1;
    public GameObject dica2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UiControl());
    }

    private IEnumerator UiControl()
    {
        yield return new WaitForSeconds(cooldownPrepare);
        Prepare.SetActive(false);
        dica1.SetActive(true);
        yield return new WaitForSeconds(cooldownKeys);
        Keys.SetActive(false);
        yield return new WaitForSeconds(cooldownDica1);
        dica1.SetActive(false);
        dica2.SetActive(true);
        yield return new WaitForSeconds(cooldownDica2);
        dica2.SetActive(false);
    }

}

