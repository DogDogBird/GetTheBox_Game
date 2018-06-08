using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    int MaxMissionCubeCnt = 6;
    public static int MissionCubeCnt;
    
    private static ScoreManager instance;

    AudioSource GameClearSound;

    public static ScoreManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<ScoreManager>();
            }
            return instance;
        }
    }
	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(gameObject);
        MissionCubeCnt = 0;
        GameClearSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        GameClear();
        Debug.Log("Mission Cube Count: " + MissionCubeCnt);
    }

    public void GameClear()
    {
        if(MissionCubeCnt >= 3)
        {
            StartCoroutine("PlayGameClearSound");
            Debug.Log("게임 클리어");
            //게임 기록 저장           
            MissionCubeCntToZero();          
            UIController.Instance.MissionCubeUI(0);
            
            
        }
    }

    IEnumerator PlayGameClearSound()
    {
        Time.timeScale = 0;
        AudioManager.Instance.BackgroundSoundOff();
        GameClearSound.Play();
        UIController.Instance.GameClearUI();
        yield return new WaitWhile(() => GameClearSound.isPlaying);
        Time.timeScale = 1;
        ScaleUpGameManager.Instance.GameOver();
    }

    public void IncrementMissionCubeCnt()
    {
        MissionCubeCnt++;
    }

    public void MissionCubeCntToZero()
    {
        MissionCubeCnt = 0;
    }

    public int getMissionCubeCnt()
    {
        return MissionCubeCnt;
    }

    public void SaveScore(float time)
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Timer", time);
    }

    public float GetHighScore()
    {
        return PlayerPrefs.GetFloat("Timer");
    }
}
