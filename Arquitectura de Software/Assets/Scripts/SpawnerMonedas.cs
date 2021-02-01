using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMonedas : MonoBehaviour
{
    //declaramos las variables necesarias para el spawn de las monedas
    [Header("variables Spawn De monedas")]
    public List<GameObject> Spawns = new List<GameObject>();
    public GameObject Seleccion;
    public int SpawnSeleccionado = 0;   
    ObjectPooling objectPooler;
    // Activamos los elementos basicos que deben estar activos desde el inicio
    void Start()
    {             
        objectPooler = ObjectPooling.llamada; 
    }
    void Update()
    {
      //comprobamos si hay alguna moneda activa
      if(GameManager._singleton.monedasActivas ==0)
      {
        //si no hay monedas se activa el spawn de monedas
        for(int i = 0;i<=Spawns.Count;i++)
        {
          SpawnMonedas();
        }
      }                  
    }
     //Aqui ocurre el spawn de las monedas ya generados en una pool.
    public void SpawnMonedas()
    {
      //se comprueba el spawn seleccionado, se genera una moneda y avanza al siguiente spawn, al llegar al ultimo spawn vuelve al primero
      if(SpawnSeleccionado < Spawns.Count)
      {
        Seleccion = Spawns[SpawnSeleccionado];
        //esta linea es la que instancia la moneda del pool
        objectPooler.SpawnFromPool("Coin",Seleccion.transform.position, Quaternion.identity);
        GameManager._singleton.monedasActivas++;
        SpawnSeleccionado++;
      }
      else
      {      
        SpawnSeleccionado = 0;            
      }              
    }
}
