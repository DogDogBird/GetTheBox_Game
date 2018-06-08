using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 m_CameraContainerStartPos;
    public Vector3 offset;
    
    public Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    // Use this for initialization
    void Start ()
    {
        offset = transform.position - player.transform.position;
        m_CameraContainerStartPos = gameObject.transform.position;
    }

    public void Update()
    {
        transform.position = player.transform.position + offset;
        //transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, 1);
    }
}
