using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Scenario_ChangeWallpaper : MonoBehaviour
{
    [SerializeField] private Material[] wallpapers;
    [SerializeField] private GameObject[] walls;
    void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");

        int temp = Random.Range(0, wallpapers.Length);

        for(int i = 0; i < walls.Length; i++)
        {
            walls[i].GetComponent<MeshRenderer>().material = wallpapers[temp];
        }
    }
}
