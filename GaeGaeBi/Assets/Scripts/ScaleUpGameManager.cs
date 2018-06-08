using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaleUpGameManager : MonoBehaviour {

    public Player player;
    public EnemyController enemy;
    public MissionCubeSpawner mcs;

    AudioSource audioSource;
    
    public bool onGame { get; set; }

    public bool isAlive;
    // Use this for initialization
    private static ScaleUpGameManager instance;

    public static ScaleUpGameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<ScaleUpGameManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        if(player)
        {
            Debug.Log(player.name);
        }
        mcs = FindObjectOfType<MissionCubeSpawner>();
        audioSource = GetComponent<AudioSource>();

        isAlive = false;
        //enemy.gameObject.SetActive(false);
        player.gameObject.SetActive(false);

        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void GameStart()
    {                 
         UIController.Instance.GameStartUI();       
    }

    //게임 오버 됐을때
    public void GameOver()
    {
        //Debug.Log("ㄲㄲ");
        //    Destroy(player);
        AudioManager.Instance.BackgroundSoundOff();
        audioSource.PlayOneShot(audioSource.clip);
        player.Die();
        //Debug.Log("WW");
        ScoreManager.Instance.SaveScore(UIController.Instance.timer);      
        UIController.Instance.GameOverUI();
        //Debug.Log("haha");
        isAlive = false;
        //ScoreManager.Instance.MissionCubeCntToZero();
        onGame = false;
        
    }

    public void onClickGameStart()
    {      
        //mcs.DestroyAllCubes();
        player.Revive();
        //enemy.RestartEnemy();
        UIController.Instance.GameStartUIClicked();
        mcs.CreateMissionCube();
        onGame = true;
        UIController.Instance.UpdateHighScoreText();
    }

    public void onClickGameOver()
    {
        isAlive = false;
        //UIController.Instance.GameOverUIClicked();
        SceneManager.LoadScene("GaeGaeBiBall");
    }
    //Mission Cube 6개 먹으면 끝

    //시간 재기

    //Enemy한테 닿으면 죽음
}
