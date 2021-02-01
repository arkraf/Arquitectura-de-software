using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemigoController : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject target;

    void Awake()
    {
      agent = GetComponent<NavMeshAgent>();
      target =GameObject.FindGameObjectWithTag("Player");
      agent.SetDestination(target.transform.position);

    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Muerte", 20f);
    }

    // Update is called once per frame
    void Update()
    {
       agent.SetDestination(target.transform.position);
        
    }

    void Muerte()
    {
      gameObject.SetActive(false);
    }
}
