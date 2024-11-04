using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject road;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            if (other.gameObject != null) 
            {
                Instantiate(road, new Vector3(0, 0, 1780f), Quaternion.identity);
            }
           
        }
        
    }
}
