using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Life : MonoBehaviour
{
    [SerializeField] private int life;

    [Header("FX")]
    [SerializeField] private AudioClip dieClip;
    [SerializeField] private AudioClip hitClip;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI playerLifeText;

    private AudioSource _audiosrc;
    private GameManager _game;

    [SerializeField] private Animator anim;

    void Start()
    {
        _audiosrc = GetComponent<AudioSource>();
        _game = Camera.main.GetComponent<GameManager>();
        playerLifeText.text = "Player Life: " + life;
    }

    public void TakeDamage(int damage)
    {
        if (life-damage>0)
        {
            life -= damage;
            if (hitClip != null)
            {
                _audiosrc.clip = hitClip;
                _audiosrc.Play();
                anim.SetTrigger("hitbb");
            }
        }
        else
        {
            if(dieClip != null)
            {
                _audiosrc.clip = dieClip;
                _audiosrc.Play();
            }
            _game.RestartGame();
            this.gameObject.SetActive(false);
        }
        playerLifeText.text = "Player Life: " + life;
    }

}
