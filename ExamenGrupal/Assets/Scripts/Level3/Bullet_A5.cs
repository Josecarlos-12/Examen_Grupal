using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_A5 : MonoBehaviour
{
    private Vector3 target;
    public AbsDamageType_A5 bulletValues;
    private void OnEnable()
    {
        target = GameObject.Find("Player").transform.position;
        Vector3 diff = target - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletValues!=null) transform.position = Vector3.MoveTowards(transform.position, target, bulletValues.GetSpeed()*Time.deltaTime);

        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IDamage_A5>() != null)
        {
            collision.gameObject.GetComponent<IDamage_A5>().GetDamage();
        }
    }

}
