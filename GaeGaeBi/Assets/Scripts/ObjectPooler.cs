using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    public void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

	// Use this for initialization
	void Start () {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> ObjectPool = new Queue<GameObject>();

            for(int i=0;i<pool.size;i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                ObjectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, ObjectPool);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnFromPool(string tag, Vector3 position)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " Doesn't exist");
            return;
        }
        
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();//Dictionary에서 빼서 ObjectToSpawn에 넣는다

        objectToSpawn.SetActive(true);//빼낸 데이터 활성화
        objectToSpawn.transform.position = position;//위치 설정
        //objectToSpawn.transform.rotation = rotation;//로테이션 설정

        poolDictionary[tag].Enqueue(objectToSpawn);//빼낸거 다시 넣는다.
        
    }
}
