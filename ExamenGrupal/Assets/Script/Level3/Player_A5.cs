using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player_A5 : MonoBehaviour, IDamage_A5
{
    public int life = 1;
    public event Action Damaged = delegate { };

    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    public void GetDamage()
    {
        life--;
        Damaged.Invoke();
    }

}
