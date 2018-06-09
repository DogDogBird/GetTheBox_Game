using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public float speed = 1000;
    Rigidbody myRigidbody;
    Transform GrenadeSpawner;
    bool grounded;

    float livingTime;
    public float power = 50.0f;
    public float radius = 50.0f;
    public float upForce = 0.1f;

    public GameObject ExplosionPrefab;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        grounded = false;
        myRigidbody.AddForce(transform.forward.normalized * speed);
    }
	
	// Update is called once per frame
	void Update ()
    {
        livingTime += Time.deltaTime;
      
        Invoke("Detonate",3);

        Debug.Log(livingTime);
        if(livingTime >= 3.3f)
        {
            DestroyImmediate(gameObject);
        }
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    void Detonate()
    {
        Instantiate(ExplosionPrefab,gameObject.transform.position,gameObject.transform.rotation);
        Vector3 explosionPosition = gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb!=null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
    }
}
