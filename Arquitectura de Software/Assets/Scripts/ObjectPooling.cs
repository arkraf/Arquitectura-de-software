using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
      public string tag;
      public GameObject prefab;
      public int size; 
    }
    
    #region Singleton

    public static ObjectPooling llamada;

    private void Awake()
    {
         llamada = this;
    }
    #endregion
    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string,Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
         Queue<GameObject> objectpool = new Queue<GameObject>();

         for (int i = 0; i < pool.size;i++)
         {
              GameObject obj = Instantiate(pool.prefab);
              obj.SetActive(false);
              objectpool.Enqueue(obj);

              
         }
         poolDictionary.Add(pool.tag, objectpool);
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
      if(!poolDictionary.ContainsKey(tag))
      {
       Debug.LogWarning("Pool with tag"+ tag + "doesn't exists.");
       return null;
      }

      GameObject objectToSpawn = poolDictionary[tag].Dequeue();

       objectToSpawn.SetActive(true);
       objectToSpawn.transform.position = position;
       objectToSpawn.transform.rotation = rotation;

       poolDictionary[tag].Enqueue(objectToSpawn);

       return objectToSpawn;

    }

    
}
