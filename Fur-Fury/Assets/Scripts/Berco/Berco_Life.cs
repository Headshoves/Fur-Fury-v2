using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Berco_Life : MonoBehaviour
{
    [SerializeField] private int life = 5;


    [Header("UI")]
    [SerializeField] private TextMeshProUGUI bercoLifeText;
    [SerializeField] private Sprite[] lifeSprites;
    [SerializeField] private Image bercoLifeImage;

    private GameManager _game;

    private void Start()
    {
        _game = Camera.main.GetComponent<GameManager>();
        bercoLifeImage.sprite = lifeSprites[life];
    }

    public void TakeDamage()
    {
        if (life > 0)
        {
            life--;
            bercoLifeImage.sprite = lifeSprites[life];
        }
        else
        {
            _game.RestartGame();
        }
    }
}
