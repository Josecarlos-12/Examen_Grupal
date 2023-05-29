using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel1 : MonoBehaviour
{
    [Header("Life") ,SerializeField] private int life = 1;

    [Header("Move"),SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.velocity = movement * speed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), transform.position.y, transform.position.z);
    }

    void ChangeLife(int value)
    {
        life += value;

        if (life <= 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DamageEnemy>() != null)
        {
            ChangeLife(-other.gameObject.GetComponent<DamageEnemy>().GetDamage());
            Destroy(other.gameObject);
        }
    }
}
