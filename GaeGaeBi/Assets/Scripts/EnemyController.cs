using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    private NavMeshAgent _agent;
    public Player target;
    public ScaleUpGameManager gameManager;

    Vector3 StartPosition;
	// Use this for initialization

    void Awake()
    {
        StartPosition = gameObject.transform.position;
        Debug.Log("Enemy Position: " + StartPosition);
        target = GameObject.Find("Player").GetComponent<Player>();
    }
	void Start ()
    {
        _agent = GetComponent<NavMeshAgent>();
        gameManager  = FindObjectOfType<ScaleUpGameManager>();
        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        _agent.destination = target.gameObject.transform.position;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.GameOver();
        }
    }

    public void RestartEnemy()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = StartPosition;
    }
}
