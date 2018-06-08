using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    Transform transform;
    AudioSource Caudio;

    public float rotationSpeed = 30;
    // Use this for initialization

    private void Awake()
    {
        Caudio = GetComponent<AudioSource>();
    }
    void Start () {
        transform = GetComponent<Transform>();       
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.Rotate(new Vector3(rotationSpeed, rotationSpeed, rotationSpeed) * Time.deltaTime);
        //회전
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            collision.gameObject.transform.localScale *= 1.5f;
            Debug.Log(collision.gameObject.transform.localScale);
            StartCoroutine(ScaleUpSound());
            
            //Time.timeScale = 1;
        }
    }

    IEnumerator ScaleUpSound()
    {
        Caudio.PlayOneShot(Caudio.clip, 1.0f);
        Debug.Log("Caudio Playing");
        yield return new WaitWhile(() => Caudio.isPlaying);        
        Destroy(gameObject);
        Time.timeScale = 1;
    }
}
