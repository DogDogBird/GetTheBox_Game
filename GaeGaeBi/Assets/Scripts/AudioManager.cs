using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    AudioSource[] sounds;
    AudioSource audioSource;
    AudioSource missioncube;
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
        sounds = GetComponents<AudioSource>();
        audioSource = sounds[0];
        missioncube = sounds[1];
    }
	
	// Update is called once per frame
	void Update () {
		    
	}

    public void BackgroundSoundOff()
    {
        audioSource.Stop();
    }
    public void MissionCubeColliderSoundOn()
    {
        missioncube.Play();
    }
}
