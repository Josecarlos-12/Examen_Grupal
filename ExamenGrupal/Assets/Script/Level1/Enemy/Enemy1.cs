using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, DamageEnemy
{
    [SerializeField] private GameObject player;
    [SerializeField, Header("Move")] private float speed = 5f;
    [SerializeField, Header("Damage")] private int damage;
    [SerializeField, Header("Life")] private int life=1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Follow();
    }

    public void Follow()
    {
        if(player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();

            transform.Translate(direction * speed * Time.deltaTime);
        }        
    }

    public int GetDamage()
    {
        return damage;
    }
    void ChangeLife(int value)
    {
        life += value;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DamagePlayer>() != null)
        {
            ChangeLife(-other.gameObject.GetComponent<DamagePlayer>().GetDamagePlayer());
            Destroy(other.gameObject);
        }
    }
}
