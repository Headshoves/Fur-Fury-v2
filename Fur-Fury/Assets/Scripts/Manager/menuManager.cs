using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource _audio;
    public AudioSource _audio2;
    public AudioClip _PressButton;
    public Animator _anim;
    public Animator _aninChang;
    public Animator _AudioChanging;
    public float Time = 3f;

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
        _anim.SetTrigger("Enter");
        _audio.clip = _PressButton;
        _audio.Play();
        _aninChang.SetTrigger("Changing");
        _AudioChanging.SetTrigger("Changing");


        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene("SampleScene");
    }


}
