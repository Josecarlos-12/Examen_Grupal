using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject[] positions;
    [SerializeField] private GameObject enemy, spawn;

    private static SpawnEnemyLevel2 instance;
    public event Action<GameObject> On;

    private void Awake()
    {
        instance = this;
    }

    public static SpawnEnemyLevel2 GetIntance()
    {
        return instance;
    }

    private void Start()
    {
        spawn.SetActive(true);

        for (int i = 0; i < positions.Length; i++)
        {
           GameObject enemys = Instantiate(enemy, positions[i].transform.position, positions[i].transform.rotation);
            On?.Invoke(enemys);
        }
    }
}
