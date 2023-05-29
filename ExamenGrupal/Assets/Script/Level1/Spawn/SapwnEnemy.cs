using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SapwnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject spawn;
    [SerializeField] private int numbersObjects;

    public static SapwnEnemy Instance { get; private set; }
    public event Action<GameObject> ObjGenerated;

    [SerializeField] float time, maxTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        GenerarObjetos();
    }

    private void GenerarObjetos()
    {
        time += Time.deltaTime;

        if(time > maxTime)
        {
            time = 0;
            spawn.SetActive(true);

            Vector3 spriteBoxMin = box.transform.position - box.transform.localScale / 2;
            Vector3 spriteBoxMax = box.transform.position + box.transform.localScale / 2;

            for (int i = 0; i < numbersObjects; i++)
            {
                float x = Random.Range(spriteBoxMin.x, spriteBoxMax.x);
                float y = Random.Range(spriteBoxMin.y, spriteBoxMax.y);
                Vector3 position = new Vector3(x, y, 0f);
                GameObject objeto = Instantiate(enemy, position, Quaternion.identity);
                ObjGenerated?.Invoke(objeto);

            }
        }

        if (time == 0)
        {
            spawn.SetActive(false);
        }
    }
}
