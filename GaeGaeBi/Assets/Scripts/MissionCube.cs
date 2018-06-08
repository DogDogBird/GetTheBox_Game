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
            ScoreManager.Instance.IncrementMissionCubeCnt();
            //gameObject.SetActive(false);
            StartCoroutine(MissionCubeSound());
            uiController.MissionCubeUI(ScoreManager.Instance.getMissionCubeCnt());
        }
    }

    IEnumerator MissionCubeSound()
    {
        audioSource.PlayOneShot(audioSource.clip, 1);
        yield return new WaitWhile(() => audioSource.isPlaying);
        Destroy(gameObject);
    }
}
