using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy_Spawn : MonoBehaviour
{
    public static Enemy_Spawn _singleton;

    [Header("Prefab Enemies")]
    [SerializeField] private GameObject[] enemyPrefab;

    [Header("Spawns List")]
    private List<Transform> _spawnList = new List<Transform>();

    [Header("Wave Manipulation")]
    [SerializeField] private int enemiesSpawned = 0;
    [SerializeField] private float timeToNewHorde = 3f;

    [Header("Wave Calibration")]
    [Header("Enemies")]
    [SerializeField] private float enemyMultiplier = 1.2f;
    [SerializeField] private List<int> totalEnemies;

    [Space(10)]

    [Header("Time Spawn")]
    [SerializeField] private float timeSpawn = 3f;


    [Header("UI Control")]
    [SerializeField] private TextMeshProUGUI textWave;
    [SerializeField] private TextMeshProUGUI inimigosRestantes;
    [SerializeField] private GameObject newHorde;

    private int enemiesKilled;

    private int _level = 0;


    private void Awake()
    {
        _singleton = this;
    }

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnList.Add(transform.GetChild(i));
        }
        InvokeRepeating("StartWave",5f,timeSpawn);

        textWave.text = "Wave: " + _level+1;
        inimigosRestantes.text = "Inimigos Restantes: " + (totalEnemies[_level] - enemiesKilled);
    }

    private void StartWave()
    {
        if (totalEnemies[_level] > enemiesSpawned)
        {
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length-1)], _spawnList[Random.Range(0, _spawnList.Count - 1)].position, Quaternion.identity);
            enemiesSpawned++;
        }
        
        if(enemiesKilled >= totalEnemies[_level])
        {
            StartCoroutine("NewHorde");
        }
    }

    private double backupEnemies;

    private IEnumerator NewHorde()
    {

        ResetValues();
        yield return new WaitForSeconds(timeToNewHorde / 2);

        newHorde.SetActive(true);

        yield return new WaitForSeconds(timeToNewHorde/2);

        NewWaveEnemyNumber();
        newHorde.SetActive(false);
        textWave.text = "Wave: " + (_level + 1);
        inimigosRestantes.text = "Inimigos Restantes: " + (totalEnemies[_level] - enemiesKilled);
    }

    public void KillEnemy()
    {
        enemiesKilled++;
        inimigosRestantes.text = "Inimigos Restantes: " + (totalEnemies[_level] - enemiesKilled);
    }

    private void ResetValues()
    {
        _level++;
        enemiesSpawned = 0;
        enemiesKilled = 0;
        CancelInvoke();
    }

    private void NewWaveEnemyNumber()
    {
        if (_level >= totalEnemies.Count)
        {
            backupEnemies = totalEnemies[^1] * enemyMultiplier;
            totalEnemies.Add((int)(backupEnemies * enemyMultiplier));
        }
        InvokeRepeating("StartWave", timeSpawn, timeSpawn);
    }

    public void Stop()
    {
        CancelInvoke();
        StopAllCoroutines();
    }
}