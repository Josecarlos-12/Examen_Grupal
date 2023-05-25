using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazController : MonoBehaviour
{
    public GameObject interfaz; 
    public GameObject objetoRebote; 

    private bool interfazVisible = true;
    private float inactivityTime = 0f;
    private float maxInactivityTime = 5f; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inactivityTime = 0f;

            if (!interfazVisible)
            {
                interfaz.SetActive(true);
                interfazVisible = true;

                objetoRebote.SetActive(false);
            }
        }
        else
        {
            inactivityTime += Time.deltaTime;

            if (inactivityTime >= maxInactivityTime && interfazVisible)
            {
                interfaz.SetActive(false);
                interfazVisible = false;

                objetoRebote.SetActive(true);
            }
        }
    }
}
