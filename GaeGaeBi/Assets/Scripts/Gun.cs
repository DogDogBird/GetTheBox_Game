using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {
    
    private static Gun instance;

    public float timeBetFire = 0.5f;

    public ParticleSystem fireEffect;

    public ParticleSystem muzzleFlashEffect;

    public Animator gunAnim;

    public AudioSource gunAudio;

    public float moveSpeed = 100;
    private Rigidbody myRigidbody;
    
    private Rigidbody GraivtyBallRigidbody;
    public float ratio = 0.5f;

    public Text VelocityText;
    public Text AngularVelocity;
    public Text VelocityIntense;
    public Text AngularGravityIntense;

    private float lastFireTime;
	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        MoveObject();

        if (lastFireTime +timeBetFire <= Time.time && GravityBall.Instance.gravityIntense >= 10f)
        {         
            lastFireTime = Time.time;
            Fire();
        }
	}

    public void MoveObject()
    {
        myRigidbody.AddForce(transform.forward * moveSpeed);
       
        float _gravityIntense = GravityBall.Instance.gravityIntense;
        if (GravityBall.Instance.IsLeft)
        {
            _gravityIntense *= (-1);
        }

        //Set text to watch the values
        VelocityText.text = "Velocity: " + GravityBall.Instance.velocity;
        AngularVelocity.text = "AngularVelocity: " + GravityBall.Instance.angularVelocity * 10000;
        VelocityIntense.text = "Velocity M: " + (int)(GravityBall.Instance.velocityIntense * 10000);
        AngularGravityIntense.text = "gravity intense M: " + (int)(_gravityIntense);

        myRigidbody.angularVelocity += GravityBall.Instance.angularVelocity * ratio*0.05f;
        myRigidbody.velocity += GravityBall.Instance.velocity * ratio * 0.01f; 

        myRigidbody.AddForce(transform.right * _gravityIntense * 100);//
    }

    public void Fire()
    {
        fireEffect.Play();
        muzzleFlashEffect.Play();
        gunAnim.SetTrigger("Fire");
        gunAudio.Play();
    }
}
