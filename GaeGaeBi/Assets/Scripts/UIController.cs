using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Canvas gameOverUI;
    public Canvas gameStartUI;
    public Text TimerText;
    public Text MissionCubeText;
    public Text HighScoreText;
    public Text GameClearText;

    public float timer { get; set; }

    private bool playing;
    // Use this for initialization
    private static UIController instance;

    public static UIController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<UIController>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        playing = true;

        gameOverUI = GameObject.Find("GameOverUI").GetComponent<Canvas>();
        gameStartUI = GameObject.Find("GameStartUI").GetComponent<Canvas>();
        TimerText = GameObject.Find("Timer Text").GetComponent<Text>();
        MissionCubeText = GameObject.Find("MissionCubeText").GetComponent<Text>();
        HighScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();
        GameClearText = GameObject.Find("ClearText").GetComponent<Text>();

        if (gameOverUI)
        {
            Debug.Log(gameOverUI.name);
        }
        else
        {
            Debug.Log("똥!");
        }

        if (gameStartUI)
        {
            Debug.Log(gameStartUI.name);
        }
        else
        {
            Debug.Log("똥!");
        }

        if (TimerText)
        {
            Debug.Log(TimerText.name);
        }
        else
        {
            Debug.Log("똥!");
        }
    }
    /* Easter egg
    decim아니;;;나도 아직 안봄..ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ아 이거 하고있었음?
        ㄴㄴ 하고있지는 않았는데.. 같이 보자 ㅠㅠ알겠엉
            언재ㅔ오ㅓ
            나 전교수님 상담!! 밥 어떡할거?나 점심 약소있음ㅇㅋㅇㅋ 점심먹고 보자
            */
    void Start ()
    {
        timer = 0;
        gameOverUI.gameObject.SetActive(false);
        GameClearText.gameObject.SetActive(false);
        gameStartUI.gameObject.SetActive(true);
        //ScoreManager.Instance.SaveScore(22);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateTimerUI();

    }   

    public void GameOverUI()
    {
        gameOverUI.gameObject.SetActive(true);
    }

    public void GameStartUI()
    {
        gameStartUI.gameObject.SetActive(true);
    }
    public void GameClearUI()
    {
        GameClearText.gameObject.SetActive(true);
    }

    public void UpdateTimerUI()
    {
        if (ScaleUpGameManager.Instance.onGame)
        {
            timer += Time.deltaTime;
            string result = string.Format("Timer: {0: #.##} sec", timer);
            TimerText.text = result;
        }
        else
        {
            timer = 0;
            string result = string.Format("Timer: {0: #.##} sec", timer);
            TimerText.text = result;
        }
    }

    public void UpdateHighScoreText()
    {
        string result = string.Format("Prev Score: {0: #.##} sec", ScoreManager.Instance.GetHighScore().ToString());
        HighScoreText.text = result;
    }

    public void MissionCubeUI(int cubeCnt)
    {
        MissionCubeText.text = cubeCnt + "/3";
    }
    public void GameStartUIClicked()
    {
        gameStartUI.gameObject.SetActive(false);
    }
    public void GameOverUIClicked()
    {  
        gameOverUI.gameObject.SetActive(false);
        gameStartUI.gameObject.SetActive(true);
    }
}
