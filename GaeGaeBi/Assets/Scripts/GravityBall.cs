using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBall : MonoBehaviour
{
    public static GravityBall Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GravityBall>();

                if (!instance)
                {
                    Debug.LogError("You didn't Create GravityBall!");
                }
            }
            return instance;
        }
    }

    private static GravityBall instance;


    public Rigidbody syncTarget;

    public float ratio = 0.2f;

    public float velocityToColorRatio = 0.5f;
    public float torqueToColorRatio = 0.2f;

    public PSMeshRendererUpdater meshRendererUpdater;
    public AudioSource intenseAudioPlayer;

    public ParticleSystem gravityBallEffect;

    public float gravityIntense { get { return gravityJoint.currentForce.magnitude * gravityIntenseFactor; } }

    private const float gravityIntenseFactor = 0.01f;

    public float angularGravityIntense { get { return gravityJoint.currentTorque.magnitude * angularGravityFactor; } }
    private const float angularGravityFactor = 0.01f;

    public float velocityIntense { get { return ballRigidbody.velocity.magnitude; } }

    public Vector3 angularVelocity { get { return ballRigidbody.angularVelocity; } }
    public Vector3 velocity { get { return ballRigidbody.velocity; } }
    public bool IsLeft { get { return (transform.position.x < 0); } }
    public bool IsDown { get { return (transform.rotation.z < 0); } }

    private Vector3 startPos;

    public Joint gravityJoint;


    private Rigidbody ballRigidbody;
    private Renderer ballRenderer;

    private Color materialColor = Color.black;

    private void Awake()
    {
        ballRenderer = GetComponent<Renderer>();
        ballRigidbody = GetComponent<Rigidbody>();

    }
    // Use this for initialization
    void Start()
    {
        startPos = ballRigidbody.position;
    }

    private void Update()
    {
        Debug.Log(transform.position.x);
        UpdateVisual();
    }

    void UpdateVisual()
    {
        materialColor = Color.black;

        materialColor.r = gravityIntense * velocityToColorRatio;
        materialColor.b = gravityJoint.currentTorque.magnitude * torqueToColorRatio;
        ballRenderer.materials[0].SetColor("_EmissionColor", materialColor);
        //Debug.Log(transform.position.y);


        if (gravityIntense > 1)
        {
            gravityBallEffect.playbackSpeed = Mathf.Clamp(gravityIntense,1,3);
            intenseAudioPlayer.pitch = Mathf.Clamp(gravityIntense, 1, 3);

        }
        else
        {
            gravityBallEffect.playbackSpeed = 0.2f;
            intenseAudioPlayer.pitch = 0.2f;
        }     


        //syncTarget.angularVelocity += ballRigidbody.angularVelocity * ratio;
        //syncTarget.velocity += ballRigidbody.velocity * ratio * 0.01f;
    }

}
