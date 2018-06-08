using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTargetWall : MonoBehaviour {

    private Rigidbody myRigidbody;
    public float moveSpeed = 100;
	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        myRigidbody.AddForce(Vector3.forward * moveSpeed);
    }
}
