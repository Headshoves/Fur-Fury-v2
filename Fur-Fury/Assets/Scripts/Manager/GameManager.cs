using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {
        Enemy_Spawn._singleton.Stop();
        StartCoroutine("EndGame");
    }

    private IEnumerator EndGame()
    {
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
