using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip bearDie;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void RestartGame()
    {
        Enemy_Spawn._singleton.Stop();
        StartCoroutine("EndGame");
    }

    private IEnumerator EndGame()
    {
        if (bearDie != null)
        {
            source.clip = bearDie;
            source.Play();
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
