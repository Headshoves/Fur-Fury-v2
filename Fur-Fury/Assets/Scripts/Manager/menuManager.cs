using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource _audio;
    public AudioClip _PressButton;
    public float Time = 1f;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 

        {

            StartCoroutine(changeScene());
        }
    }
    IEnumerator changeScene() 
    {
        _audio.clip = _PressButton;
        _audio.Play();
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene("SampleScene");
    }


}
