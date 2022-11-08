using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Berco_Life : MonoBehaviour
{
    //Life Count
    [SerializeField] private int life = 5;

    public GameObject player;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI bercoLifeText;
    [SerializeField] private Sprite[] lifeSprites;
    [SerializeField] private Image bercoLifeImage;

    [SerializeField] public Animator _animChanging;
    //Components
    private GameManager _game;

    public GameObject Lanterna;

    [SerializeField] public Animator animPlayer;

    private void Start()
    {
        _game = Camera.main.GetComponent<GameManager>();
        bercoLifeImage.sprite = lifeSprites[life];
    }

    public void TakeDamage()
    {
        life--;
        bercoLifeImage.sprite = lifeSprites[life];

        if (life <= 0)
             _game.RestartGame();
            StartCoroutine(Restart());
            
            animPlayer.SetBool("ISRunning", false);

    }

    private IEnumerator Restart()
    {

        player.GetComponent<Player_Movement>().enabled = false;
        player.GetComponent<Player_Fire>().enabled = false;
        player.GetComponent<Player_LookCursor>().enabled = false;
        Lanterna.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(2f);
        _animChanging.SetTrigger("Changing");
        yield return new WaitForSeconds(0.3f);
        _game.RestartGame();

    }



}
