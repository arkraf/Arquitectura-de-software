using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //declaramos las variables necesarias para el spwan de enemigos
    [Header("gameObjects")]
    public GameObject SpawnEnemigo;
    
    [Header("variables Spawn De enemigos")]
    [SerializeField]private float tiempoSpawn;
    [SerializeField]private float tiempo;
    ObjectPooling objectPooler;
    //Activamos los elementos basicos que deben estar activos desde el inicio
    void Start()
    {
        objectPooler = ObjectPooling.llamada;                       
    }
    //llevamos el registro del tiempo que pasa y comprobamos cuando debe activarse los enemigos
    void Update()
    {     
       //Aqui ocurre el spawn de los enemigos ya generados en una pool.               
        tiempo +=Time.deltaTime;
        //comprobamos si debe activarse el enemigo
        if(tiempo >= tiempoSpawn)
        {         
          //esta linea es la que activa al enemigo del pool          
          objectPooler.SpawnFromPool("Enemigo", SpawnEnemigo.transform.position, Quaternion.identity);
          tiempo = 0;
        }                  
    }      
}
