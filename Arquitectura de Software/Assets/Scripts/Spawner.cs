using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("gameObjects")]
    public GameObject EnemigoPrefab;
    public GameObject Spawn;

    [Header("variables Spawn")]
    [SerializeField]private float tiempoSpawn =10f;
    [SerializeField]private float tiempo =0;

    ObjectPooling objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooling.llamada;

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < tiempoSpawn;i++)
        {          
          tiempo += 1*Time.deltaTime;
          if(tiempo >= tiempoSpawn)
          {
           //Instantiate(EnemigoPrefab).transform.position = Spawn.transform.position;
           objectPooler.SpawnFromPool("Enemigo", Spawn.transform.position, Quaternion.identity);
           tiempo = 0;
          }
          
        }
        
    }

    
}
