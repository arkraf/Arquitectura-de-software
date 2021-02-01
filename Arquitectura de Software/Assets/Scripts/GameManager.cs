using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _singleton;
    
    [Header("Estadísticas de monedas")]
    public int monedas= 0;
    public TextMeshProUGUI ContadorMonedas;

    [Header("Variables de tiempo de juego")]
    public int tiempoLimite;
    public int tiempoActual;
    public TextMeshProUGUI ContadorTiempo;



    void Awake(){

        if (_singleton == null){

            _singleton = this;
            DontDestroyOnLoad(this.gameObject);
    
            //Rest of your Awake code
    
        } else {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ContadorMonedas.text =("Coins:")+ monedas;
        
        tiempoActual= tiempoLimite;
        ContadorTiempo.text =("Tiempo:")+ tiempoActual;

    }

    // Update is called once per frame
    void Update()
    {
        

    }


}
