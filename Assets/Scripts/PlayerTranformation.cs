using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTranformation : MonoBehaviour
{
    [SerializeField] private int dulcesF1, dulcesF2, dulcesF3;
    [SerializeField] private int dulcesActuales;
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
        if (other.CompareTag("Dulces"))
        {
            dulcesActuales++;
            if (dulcesActuales == dulcesF1) 
            {
                //Aumentar tamano
                transform.localScale = new Vector3(2, 2, 2);
            }
            if (dulcesActuales == dulcesF2)
            {
                //Aumentar tamano
                transform.localScale = new Vector3(3, 3, 3);
            }
            if (dulcesActuales == dulcesF3)
            {
                //Aumentar tamano
                transform.localScale = new Vector3(4, 4, 4);
            }
        }
    }
}
