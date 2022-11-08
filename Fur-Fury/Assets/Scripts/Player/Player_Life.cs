using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    //Life Count
    [SerializeField] private int life;

    //Sound
    [Header("Sound")]
    [SerializeField] private AudioClip hitClip;

    //UI Control
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI playerLifeText;
    [SerializeField] private Sprite[] lifeSprites;
    [SerializeField] private Image playerLifeImage;

    private AudioSource _audiosrc;
    private GameManager _game;

    [SerializeField] private Animator anim;
    [SerializeField] public Animator animPlayer;

    public GameObject Lanterna;

    void Start()
    {
        _audiosrc = GetComponent<AudioSource>();
        _game = Camera.main.GetComponent<GameManager>();

        playerLifeImage.sprite = lifeSprites[life];
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        playerLifeImage.sprite = lifeSprites[life];
        print(life);

        if (life>0)
        {
            
            if (hitClip != null)
            {
                _audiosrc.clip = hitClip;
                _audiosrc.Play();
                anim.SetTrigger("hitbb");
                animPlayer.SetTrigger("hit");
            }
        }
        else
        {
            animPlayer.SetBool("ISRunning", false);
            animPlayer.SetBool("Dead", true);
            StartCoroutine(Restart());
        }    
    }


    private IEnumerator Restart()
    {
       
        this.gameObject.GetComponent<Player_Movement>().enabled = false;
        this.gameObject.GetComponent<Player_Fire>().enabled = false;
        this.gameObject.GetComponent<Player_LookCursor>().enabled = false;
        Lanterna.GetComponent<Light>().enabled = false;
        
        yield return new WaitForSeconds(5f);
        _game.RestartGame();

    }

}
