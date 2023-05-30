using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulltetEnemy : Bullet, DamagePlayer
{
    [SerializeField, Header("Damage")] private int damage = 1;

    private void Start()
    {
        Destroy(gameObject, timeLife);
    }
    public int GetDamagePlayer()
    {
        return damage;
    }
}
