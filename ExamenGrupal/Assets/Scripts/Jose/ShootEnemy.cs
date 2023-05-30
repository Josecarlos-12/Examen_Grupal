using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform point;

    [SerializeField] private float time, maxTime;

    void Update()
    {
        time += Time.deltaTime;

        if(time>maxTime)
        {
            time = 0;
            Instantiate(bullet, point.position, point.rotation);
        }
    }
}
