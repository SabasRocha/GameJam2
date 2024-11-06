using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerTranformation : MonoBehaviour
{
    [SerializeField] private int dulcesF1, dulcesF2, dulcesF3;
    [SerializeField] private int puntajeActual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candy") && other != null)
        {
            //puntajeActual += other.GetComponent<Candy>().puntajeDulce;
            if (puntajeActual == dulcesF1) 
            {
              
            }
            if (puntajeActual == dulcesF2)
            {
                //Aumentar tamano
                
            }
            if (puntajeActual == dulcesF3)
            {
                //Aumentar tamano

            }
        }
    }
}
