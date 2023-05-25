using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public int chargeCredits = 0;
    public TextMeshProUGUI chargeText;

    public string[] membersNames;
    public TextMeshProUGUI textGroup;
    public float timeBetweenNames = 2f;

    private int currentIndex = 0;
    private float timeNextName = 0f;
    private int sceneLoadCount = 0;

    private static CreditsController instance;

    public delegate void ChargeCreditsDelegate(int cargas);
    public static event ChargeCreditsDelegate CreditsChargeUpdated;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        sceneLoadCount++;
        ActualizarTextoCargas();
        MostrarSiguienteNombre();
    }

    private void Update()
    {
        if (Time.time >= timeNextName)
        {
            MostrarSiguienteNombre();
        }
    }

    private void ActualizarTextoCargas()
    {
        chargeText.text = "Cargo: " + sceneLoadCount.ToString();

        CreditsChargeUpdated?.Invoke(chargeCredits);
    }

    private void MostrarSiguienteNombre()
    {
        if (membersNames.Length == 0)
        {
            return; 
        }

        textGroup.text = membersNames[currentIndex];
        currentIndex++;
        if (currentIndex >= membersNames.Length)
        {
            currentIndex = 0; 
        }

        timeNextName = Time.time + timeBetweenNames;
    }

    public static CreditsController ObtenerInstancia()
    {
        return instance;
    }

}
