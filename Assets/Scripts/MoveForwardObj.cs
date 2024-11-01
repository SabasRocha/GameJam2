using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveForwardObj : MonoBehaviour
{
    float movementZ, limiter = 20f, distanceDestroy= -10f;
    private Rigidbody candyRB;

    void Start()
    {
        transform.position = transform.position;
        if(gameObject.CompareTag("Candy"))
        {
            candyRB = gameObject.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndRotateElements();
        DestroyElements();
    }

    void MoveAndRotateElements()
    {
        if (gameObject.CompareTag("Candy"))
        {
            
            candyRB.AddTorque(0, 0, 15, ForceMode.Force);
            transform.Translate(0, (limiter * Time.deltaTime), 0);
        }
        else
        {
            transform.Translate(0, -(limiter * Time.deltaTime), 0);
        }
        
        
    }

    void DestroyElements()
    {
        if (transform.position.z < distanceDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
