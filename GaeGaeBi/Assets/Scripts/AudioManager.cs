using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    AudioSource audioSource;
    // Use this for initialization

    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }

	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackgroundSoundOff()
    {
        audioSource.Stop();
    }
}
