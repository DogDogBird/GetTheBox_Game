using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCube : MonoBehaviour {

    UIController uiController;
    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        uiController = FindObjectOfType<UIController>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {           
            //gameObject.SetActive(false);
            StartCoroutine(GetItem());         
        }
    }

    IEnumerator GetItem()
    {
        AudioManager.Instance.MissionCubeColliderSoundOn();
        //audioSource.PlayOneShot(audioSource.clip, 1);
        yield return null;
        ScoreManager.Instance.IncrementMissionCubeCnt();
        DestroyImmediate(gameObject);
        uiController.MissionCubeUI(ScoreManager.Instance.getMissionCubeCnt());
    }
}
