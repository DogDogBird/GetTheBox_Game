using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    float nextSpawnTime;
    public float timeBetweenSpawns;
    public GameObject item;

    private void Start()
    {
        timeBetweenSpawns = 5;
    }
    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(item,transform.position + new Vector3(Random.Range(-30f,30f),0, Random.Range(-30f, 30f)), transform.rotation);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }

    
}
