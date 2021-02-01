using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    //Comprobamos la collision del jugador con la moneda   
    public void OnTriggerEnter(Collider other)
    {
      if (other.tag == ("Player"))
      {
        //sumamos los datos correspondientes por coger la moneda y la desactivamos para devolverla al pool de monedas
       GameManager._singleton.monedas += 1;
       GameManager._singleton.tiempoActual+=5;
       GameManager._singleton.ContadorMonedas.text =("Coins:")+ GameManager._singleton.monedas;   
       GameManager._singleton.monedasActivas--;  
       gameObject.SetActive(false);

      }
    }
}
