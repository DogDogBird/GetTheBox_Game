using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerController))]
public class Player : MonoBehaviour {
    
    public float moveSpeed = 300f;
    PlayerController controller;
    public float horizontalController;
    public float verticalController;

    public Vector3 startPosition;

    bool grounded;
    // Use this for initialization
    private void Awake()
    {
        startPosition = gameObject.transform.position;
        Debug.Log("Start Position: " + startPosition);
    }

    void Start () {
        controller = GetComponent<PlayerController>();
        
    }
    
	// Update is called once per frame
	void Update ()
    {
        if (GravityBall.Instance.IsLeft)
        {
            horizontalController = -GravityBall.Instance.gravityIntense;
        }
        else
        {
            horizontalController = GravityBall.Instance.gravityIntense;
        }

        if (GravityBall.Instance.IsDown)
        {
            verticalController = -GravityBall.Instance.gravityIntense;
        }
        else
        {
            verticalController = GravityBall.Instance.gravityIntense;
        }
        Vector3 moveInput = new Vector3(horizontalController + Input.GetAxisRaw("Horizontal"), 0, verticalController + Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.move(moveVelocity);
    }   
    public void Revive()
    {
        gameObject.transform.position = startPosition; //시작 위치로 이동
        gameObject.SetActive(true); //다시 재생성
    }
    public void Die()
    {
        Debug.Log(gameObject.name + "sss");
        gameObject.SetActive(false);
    }
}
