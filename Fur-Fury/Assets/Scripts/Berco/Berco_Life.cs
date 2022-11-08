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

    //Components
    private GameManager _game;

    public GameObject Lanterna;

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

    }

    private IEnumerator Restart()
    {

        player.GetComponent<Player_Movement>().enabled = false;
        player.GetComponent<Player_Fire>().enabled = false;
        player.GetComponent<Player_LookCursor>().enabled = false;
        Lanterna.GetComponent<Light>().enabled = false;

        yield return new WaitForSeconds(5f);
        _game.RestartGame();

    }



}
