using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    float nextSpawnTime;
    public float timeBetweenSpawns;
    public GameObject enemyPrefab;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(enemyPrefab, transform.position + new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f)), transform.rotation);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
