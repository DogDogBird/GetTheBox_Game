using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : MonoBehaviour {

    Rigidbody myRigidbody;

    public float moveSpeed = 3f;
    int count = 1;


    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f))
        {
            //myRigidbody.AddTorque(Vector3.left);
            transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y - 90f, 0);
        
            //Quaternion.EulerAngles(0, transform.rotation.y - 90f, 0);
            
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
            Debug.Log("부딫힘: " + hit.collider.gameObject.name);
            Debug.Log("각도: " + transform.localEulerAngles);
            
        }
       
           
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) , Color.yellow);
          

        myRigidbody.MovePosition(gameObject.transform.position + transform.TransformDirection(Vector3.forward) * moveSpeed * Time.deltaTime);
        count = 1;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScaleUpGameManager.Instance.GameOver();
        }
    }
}
