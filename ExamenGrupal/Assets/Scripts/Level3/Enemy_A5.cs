using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A5 : MonoBehaviour
{
    private float timer = 0;
    public float waitToShoot;
    public float waitToChange;
    public GameObject bullet;
    public AbsDamageType_A5 bulletVal;
    public EnemySpawner_A5 spawner;
    public bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        bulletVal = new AbsDamageType_A5(1, 7);

    }
    private void OnEnable()
    {
        timer =0;
        shoot = false;
    }
    public void ShootIA()
    {
        timer += Time.deltaTime;
        if (timer > waitToShoot && shoot == false)
        {
            Shoot();
            shoot = true;
        }

        if (timer > waitToChange)
        {
            spawner.Reposition();
        }

    }

    public void Shoot()
    {
        GameObject bllt = Instantiate(bullet);
        bllt.transform.position = gameObject.transform.position;
        bllt.GetComponent<Bullet_A5>().bulletValues = bulletVal;
    }
    // Update is called once per frame
    void Update()
    {
        ShootIA();
    }
}
