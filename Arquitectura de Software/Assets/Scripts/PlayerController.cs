using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    public float speed= 5f;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal= Input.GetAxis("Horizontal");
        float vertical= Input.GetAxis("Vertical");
        Vector3 direction= new Vector3(horizontal,0f,vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
        
        
    }
}
