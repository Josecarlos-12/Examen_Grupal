using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float time;
    [Header("UI"), SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        TimeElapse();
    }

    public void TimeElapse()
    {
        timeText.text= time.ToString("0");

        if(time > 0)
        time -= Time.deltaTime;

        if(time <= 0)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
