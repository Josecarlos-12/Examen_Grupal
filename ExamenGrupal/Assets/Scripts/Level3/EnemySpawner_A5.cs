using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemySpawner_A5 : MonoBehaviour
{
    public int maxSpawnMoves;
    public int actualMoves = 0;
    public GameObject[] spawnpoints;
    public GameObject enemy;
    public event Action Repositioned = delegate { };
    // Start is called before the first frame update
    void Start()
    {
        Reposition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reposition()
    {
        if (actualMoves <= maxSpawnMoves)
        {
            enemy.SetActive(false);
            enemy.transform.position = spawnpoints[UnityEngine.Random.Range(0, spawnpoints.Length)].transform.position;
            enemy.SetActive(true);

            actualMoves++;
            Repositioned.Invoke();
        }
    }
}
