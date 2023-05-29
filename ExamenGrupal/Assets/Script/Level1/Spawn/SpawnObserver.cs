using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObserver : MonoBehaviour
{
    private void OnEnable()
    {
        SapwnEnemy.Instance.ObjGenerated += Change;
    }

    private void OnDisable()
    {
        SapwnEnemy.Instance.ObjGenerated -= Change;
    }

    private void Change(GameObject objetoGenerado)
    {
        objetoGenerado.GetComponent<MeshRenderer>().material.color= Color.red;        
    }

    
}
