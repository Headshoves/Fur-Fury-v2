using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Berco_Life : MonoBehaviour
{
    [SerializeField] private int life = 5;


    [Header("UI")]
    [SerializeField] private TextMeshProUGUI bercoLifeText;

    private GameManager _game;

    private void Start()
    {
        _game = Camera.main.GetComponent<GameManager>();
        bercoLifeText.text = "Berço Life: " + life;
    }

    public void TakeDamage()
    {
        if (life > 0)
        {
            life--;
        }
        else
        {
            _game.RestartGame();
        }

        bercoLifeText.text = "Berço Life: " + life;
    }
}
