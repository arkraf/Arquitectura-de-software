using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("gameObjects")]
    public GameObject EnemigoPrefab;
    public GameObject SpawnEnemigo;

    [Header("variables Spawn De enemigos")]

    [SerializeField]private float tiempoSpawn =20f;
    [SerializeField]private float tiempo =0;
    [SerializeField]private bool BoolEnemigo;

    [Header("variables Spawn De monedas")]
    public List<GameObject> Spawns = new List<GameObject>();
    [SerializeField]private GameObject MonedaPrefab;
    [SerializeField]private GameObject Seleccion;
    [SerializeField]private int SpawnSeleccionado = 0; 
    [SerializeField]private bool BoolMoneda;
    ObjectPooling objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooling.llamada;
        if(BoolMoneda == true)
        {
          SpawnerMonedas();
        }
        

    }
    // Update is called once per frame
    void Update()
    {
      if(BoolEnemigo == true)
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
      }
        
        

        
    }
    //Aqui ocurre el spawn de las monedas ya generados en una pool.
    public void SpawnerMonedas()
    {
      SpawnSeleccionado = Random.Range(0,9);
      Seleccion = Spawns[SpawnSeleccionado].gameObject;

      objectPooler.SpawnFromPool("Coin",Seleccion.transform.position, Quaternion.identity);
      
    }

    
}
