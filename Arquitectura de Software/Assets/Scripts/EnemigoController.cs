using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemigoController : MonoBehaviour
{
    //Declaramos las variables necesarias para que el enemigo se mueva
    NavMeshAgent agent;
    GameObject target;
    //Asignamos los valores iniciales necesarios
    void Awake()
    {
      agent = GetComponent<NavMeshAgent>();
      target =GameObject.FindGameObjectWithTag("Player"); 
    }
    //Declaramos cuando debe desactivarse el enemigo
    void Start()
    {
        Invoke("Muerte", 5f);
    }
    
    void Update()
    {
      //comprobamos si el jugador esta vivo y actualizamos el objetivo de los enemigos
      if(GameManager._singleton.PlayerVivo ==true)
       agent.SetDestination(target.transform.position);
        
    }
    //comprobamos la collision del enemigo con el jugador
    public void OnTriggerEnter(Collider other)
    {
      if(other.tag ==("Player"))
      {
        GameManager._singleton.muerte();
      }
    }
    //esta funcion desactiva el enemigo devolviendolo a la pool de enemigos
    public void Muerte()
    {
      gameObject.SetActive(false);
    }
}
