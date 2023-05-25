using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObsGameConditions_A5 : MonoBehaviour
{
    public static ObsGameConditions_A5 Instance;
    public string victoryScene;
    public string loseScene;
    public Player_A5 player;
    public EnemySpawner_A5 spawner;
    public Text spawnCount;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if(SceneManager.GetActiveScene().name == "Level3")
        {
            player = GameObject.Find("Player").GetComponent<Player_A5>();
            spawner = GameObject.Find("SpawnPoints").GetComponent<EnemySpawner_A5>();
            spawnCount = GameObject.Find("Score").GetComponent<Text>();

            if (player)
            {
                player.Damaged += Lose;
                Debug.Log("Lose register");
            }
            if(spawner)
            {
                spawner.Repositioned += CheckWin;
                Debug.Log("CheckWin register");
            }
        }
    }
    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (player)
            {
                player.Damaged -= Lose;
            }
            if (spawner)
            {
                spawner.Repositioned -= CheckWin;
            }
        }
    }
    private void Lose()
    {
        Debug.Log("ChangeToLose");
        SceneManager.LoadScene(loseScene);
   
    }

    private void CheckWin()
    {
        Debug.Log("RefreshText");
        spawnCount.text = "¡" + spawner.actualMoves + "!";
        
        if(spawner.actualMoves>spawner.maxSpawnMoves)
        {
            Debug.Log("ChangeToWin");
            SceneManager.LoadScene(victoryScene);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
