using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
      if (other.tag == ("Player"))
      {
       GameManager._singleton.monedas += 1;
       GameManager._singleton.ContadorMonedas.text =("Coins:")+ GameManager._singleton.monedas;
       gameObject.SetActive(false);

      }
    }
}
