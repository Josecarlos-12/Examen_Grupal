using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObserverLevel2 : MonoBehaviour
{
    private void OnEnable()
    {
        SpawnEnemyLevel2.GetIntance().On += ChangeColor;
    }

    private void OnDisable()
    {
        SpawnEnemyLevel2.GetIntance().On -= ChangeColor;
    }

    private void ChangeColor(GameObject objetoGenerado)
    {
        objetoGenerado.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
