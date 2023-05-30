using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI distanceText;
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = new Vector3(0, player.position.y, 0);
    }

    private void Update()
    {
        float distance = Vector3.Distance(startingPosition, new Vector3(0, player.position.y, 0));

        distanceText.text = "Distancia recorrida: " + distance.ToString("F2") + " unidades";
    }
}
