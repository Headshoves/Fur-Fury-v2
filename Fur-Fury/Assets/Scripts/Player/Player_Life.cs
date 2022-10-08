using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    [SerializeField] private int life;

    [Header("FX")]
    [SerializeField] private AudioClip hitClip;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI playerLifeText;
    [SerializeField] private Sprite[] lifeSprites;
    [SerializeField] private Image playerLifeImage;

    private AudioSource _audiosrc;
    private GameManager _game;

    [SerializeField] private Animator anim;

    void Start()
    {
        _audiosrc = GetComponent<AudioSource>();
        _game = Camera.main.GetComponent<GameManager>();

        playerLifeImage.sprite = lifeSprites[life];
    }

    public void TakeDamage(int damage)
    {
        if (life-damage>0)
        {
            life -= damage;
            print(life);
            playerLifeImage.sprite = lifeSprites[life];
            if (hitClip != null)
            {
                _audiosrc.clip = hitClip;
                _audiosrc.Play();
                anim.SetTrigger("hitbb");
            }
        }
        else
        {
            playerLifeImage.sprite = lifeSprites[life];
            _game.RestartGame();
            this.gameObject.SetActive(false);
        }
    }

}
