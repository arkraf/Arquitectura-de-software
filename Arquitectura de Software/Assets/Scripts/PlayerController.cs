using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declaramos las variable de control del jugador
    [Header("variables de control del player")]
    public float speed= 5f;
    public Rigidbody rb;
    Vector3 movimiento;

    // Start is called before the first frame update
    void Start()
    {
        //asignamos el rigidbody del jugador
        rb = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //recogemos los inputs de movimiento del jugador
        movimiento.x= Input.GetAxisRaw("Horizontal");
        movimiento.z= Input.GetAxisRaw("Vertical");    
    }
    void FixedUpdate()
    {
        //aplicamos los inputs recibidos sobre el jugador para realizar el movimiento
        rb.MovePosition(rb.position + movimiento* speed* Time.fixedDeltaTime);
    }
}
