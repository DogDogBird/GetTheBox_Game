using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReticle : MonoBehaviour {

    public Player player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        gameObject.transform.position = player.gameObject.transform.position + moveDirection;
        player.transform.LookAt(gameObject.transform);
	}
}
