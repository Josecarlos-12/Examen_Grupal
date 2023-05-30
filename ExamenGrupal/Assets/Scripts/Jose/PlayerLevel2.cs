using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel2 : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    float moveVertical;

    [SerializeField] private int life = 1;


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
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            moveVertical = 0;
        }


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (movement.y < 0 && rb.position.y <= 0)
        {
            movement.y = 0;
        }

        rb.velocity = movement * speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), transform.position.y, transform.position.z);
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
            print(life);
        }
        else if (other.gameObject.CompareTag("WinCollider")) 
        {
            SceneManager.LoadScene("Win"); 
        }
    }
}
