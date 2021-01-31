using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("gameObjects")]
    public GameObject EnemigoPrefab;
    public GameObject SpawnEnemigo;

    [Header("variables Spawn De enemigos")]
    [SerializeField]private float tiempoSpawn =10f;
    [SerializeField]private float tiempo =0;

    [Header("variables Spawn De monedas")]
    public List<GameObject> listaSpawns;
    ObjectPooling objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooling.llamada;

    }
    // Update is called once per frame
    void Update()
    {

        //Aqui ocurre el spawn de los enemigos ya generados en una pool.
        for(int i = 0;i < tiempoSpawn;i++)
        {          
          tiempo += 1*Time.deltaTime;
          if(tiempo >= tiempoSpawn)
          {         
           //esta linea es la que activa al enemigo del pool          
           objectPooler.SpawnFromPool("Enemigo", SpawnEnemigo.transform.position, Quaternion.identity);
           tiempo = 0;
          }        
        }
        //Aqui ocurre el spawn de las monedas ya generados en una pool.
        //objectPooler.SpawnFromPool("Coin", Spawn.transform.position, Quaternion.identity);
    }

    
}
