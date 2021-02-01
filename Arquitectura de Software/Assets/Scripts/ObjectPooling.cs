using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //Declaramos las variables necesarias para crear el object pool
    [System.Serializable]
    public class Pool
    {
      public string tag;
      public GameObject prefab;
      public int size; 
    }
    //declaramos el singleton para poder usarlo en los otros scripts
    #region Singleton

    public static ObjectPooling llamada;

    private void Awake()
    {
         llamada = this;
    }
    #endregion
    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDict;
    // Start is called before the first frame update
    void Start()
    {      
        poolDict = new Dictionary<string,Queue<GameObject>>();
        //comprueba cada pool declarada e instancia el numero de objetos indicado en cada una , todos desactivados.
        foreach(Pool pool in pools)
        {
         Queue<GameObject> objectpool = new Queue<GameObject>();
         //instancia y desactiva los objetos de la pool hasta llegar al numero maximo declarado
         for (int i = 0; i < pool.size;i++)
         {
              GameObject obj = Instantiate(pool.prefab);
              obj.SetActive(false);
              objectpool.Enqueue(obj);              
         }
         poolDict.Add(pool.tag, objectpool);
        }
    }
    //al llamar esta funcion activamos los objetos de la pool seleccionada en la posicion que le digamos
    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
      //si el tag escrito no es correcto devuelve un aviso
      if(!poolDict.ContainsKey(tag))
      {
       Debug.LogWarning("Pool with tag"+ tag + "doesn't exists.");
       return null;
      }
      //aqui se activa el objeto y se establece la posicion y rotacion
      GameObject objectToSpawn = poolDict[tag].Dequeue();

       objectToSpawn.SetActive(true);
       objectToSpawn.transform.position = position;
       objectToSpawn.transform.rotation = rotation;

       poolDict[tag].Enqueue(objectToSpawn);

       return objectToSpawn;

    }
    

    
}
