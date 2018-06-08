using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCubeSpawner : MonoBehaviour {

    public GameObject MissionCubePrefab;
    public Transform[] SpawnPositions;

    bool newGameStart;
	// Use this for initialization
	void Start () {
        newGameStart = true;
    }
	
	// Update is called once per frame
	void Update () {
       

    }

    public void CreateMissionCube()
    {
        int prev1 = 6;
        int prev2 = 6;
        int randomNumber ;
        for (int i = 0; i < 3; i++)
        {
            randomNumber = Random.Range(0, 5);
            if (randomNumber != prev1 && randomNumber != prev2)
            {              
                GameObject.Instantiate(MissionCubePrefab, SpawnPositions[randomNumber]);
            }
            else
            {
                i--;
            }

            if (i == 0)
            {
                prev1 = randomNumber;
            }
            else if (i==1)
            {
                prev2 = randomNumber;
            }
            Debug.Log("Random No. : " + randomNumber);
        }
    }
}
