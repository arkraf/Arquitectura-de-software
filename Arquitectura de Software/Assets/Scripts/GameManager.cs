using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   // este es el gameManager en el que controlamos las estadisticas del juego
    [Header("Estadísticas de monedas")]
    public int monedas= 0;
    public TextMeshProUGUI ContadorMonedas;
    public int monedasActivas= 0;

    [Header("Variables de tiempo de juego")]
    public float tiempoLimite;
    public float tiempoActual;
    public TextMeshProUGUI ContadorTiempo;

    [Header("variables de control de vida del player")]
    public GameObject Player;
    public bool PlayerVivo = true;
    public TextMeshProUGUI FinDeJuego;
    //aqui declaramos el singleton para poder usar el gamemanager en el resto de scripts
    #region singleton
    
    public static GameManager _singleton;
    void Awake(){

        if (_singleton == null){

            _singleton = this;
            DontDestroyOnLoad(this.gameObject);
    
            //Rest of your Awake code
    
        } else {
            Destroy(this);
        }
    }
    #endregion
    
    void Start()
    {
        //en el start asignamos las variables necesarias para el control del juego
        ContadorMonedas.text =("Coins:")+ monedas;
        
        tiempoActual= tiempoLimite;
        ContadorTiempo.text =("Tiempo:")+ tiempoActual;

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    //comprobamos si el jugador esta vivo y llevamos la cuenta del tiempo que pasa
    void Update()
    {
        if(PlayerVivo==true)
        {
             //aqui actualizamos el tiempo cada segundo
            timer();

            //comprobamos si se acaba el tiempo, causando asi la derrota
            if(tiempoActual <=0)
            {
              muerte();
            }
        }   
    }
    //esta función ejecuta la muerte del jugador 
    public void muerte()
    {
        Destroy(Player.gameObject);
        PlayerVivo = false;
        FinDeJuego.text = ("Has muerto");
    }
    //esta función cuenta el tiempo que pasa
    public void timer()
    {
        tiempoActual-= Time.deltaTime;
        ContadorTiempo.text =("Tiempo:")+ tiempoActual.ToString("f0");
    }
}
