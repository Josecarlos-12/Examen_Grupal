using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public static ButtonHandler Instance { get; private set; }

    public delegate void SceneChangeDelegate(string sceneName);
    public event SceneChangeDelegate OnSceneChange;

    public int credits;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GoToCredits()
    {
        

        SceneManager.LoadScene("Credits");
        OnSceneChange?.Invoke("Credits");
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1");
        OnSceneChange?.Invoke("Level1");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level2");
        OnSceneChange?.Invoke("Level2");
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level3");
        OnSceneChange?.Invoke("Level3");
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("MainMenu");
        OnSceneChange?.Invoke("MainMenu");
    }
}
