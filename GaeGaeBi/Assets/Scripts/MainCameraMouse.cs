using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMouse : MonoBehaviour {
    private Transform myTransform;
    public float rotateSpeed;
	// Use this for initialization
	void Start ()
    {
        myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 targetRotateVectorLeft = new Vector3(myTransform.rotation.x, -rotateSpeed, myTransform.rotation.z);
        Vector3 targetRotateVectorRight = new Vector3(myTransform.rotation.x, rotateSpeed, myTransform.rotation.z);
        Vector3 targetRotateVectorUp = new Vector3(rotateSpeed, myTransform.rotation.y, myTransform.rotation.z);
        Vector3 targetRotateVectorDown = new Vector3(-rotateSpeed, myTransform.rotation.y, myTransform.rotation.z);
        if (Input.GetKey(KeyCode.A))
        {
            myTransform.Rotate(Vector3.Lerp(myTransform.rotation.eulerAngles, targetRotateVectorLeft, 10f));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myTransform.Rotate(Vector3.Lerp(myTransform.rotation.eulerAngles, targetRotateVectorRight, 10f));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            myTransform.Rotate(Vector3.Lerp(myTransform.rotation.eulerAngles, targetRotateVectorUp, 10f));           
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myTransform.Rotate(Vector3.Lerp(myTransform.rotation.eulerAngles, targetRotateVectorDown, 10f));
        }
    }
}
