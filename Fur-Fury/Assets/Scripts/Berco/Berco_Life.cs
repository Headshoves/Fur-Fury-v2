using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Berco_Life : MonoBehaviour
{
    //Life Count
    [SerializeField] private int life = 5;


    [Header("UI")]
    [SerializeField] private TextMeshProUGUI bercoLifeText;
    [SerializeField] private Sprite[] lifeSprites;
    [SerializeField] private Image bercoLifeImage;

    //Components
    private GameManager _game;

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
    }
}
