using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

    Rigidbody myRigidbody;
    Vector3 velocity;
    public GameObject target;
    public Grenade grenade;
    public Transform grenadeSpawner;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	public void move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
        
    }
    public void Update()
    {
        throwGrenade();
    }

    public void throwGrenade()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            //Debug.Log("throwGrenade");
            //Instantiate(grenadePrefab, grenadeSpawner);
        }
    }

    public void Shoot()
    {
        Grenade newGrenade = Instantiate(grenade, grenadeSpawner.position, grenadeSpawner.rotation) as Grenade;
        //newGrenade.setSpeed(10);
    }
}
