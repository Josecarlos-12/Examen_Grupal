using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsDamageType_A5 
{


    private int amoutDamage;
    private int speed;


    public AbsDamageType_A5(int damage,int spd)
    {
        speed = spd;
        amoutDamage = damage;
    }
    public int GetSpeed()
    {
        return speed;
    }
    public int GetDamage()
    {
        return amoutDamage;
    }
}
