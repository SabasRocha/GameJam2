using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveForwardObj : MonoBehaviour
{
    public static float movementZ, speed = 50f, speedIncrease = 0.09f, globalSpeed, distanceDestroyRaod = -1791, distanceDestroyAssets = -10;
    private Rigidbody candyRB;
    public float globalSpeedPub;

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
        
    }

    private void FixedUpdate()
    {
        MoveAndRotateElements();
        DestroyElements();
        speed +=speedIncrease  * Time.deltaTime;
        globalSpeed = Mathf.Min(3, (speed * Time.deltaTime));
    }

    void MoveAndRotateElements()
    {
        if (gameObject.CompareTag("Candy"))
        {

            candyRB.AddTorque(0, 0, 15, ForceMode.Force);
            transform.Translate(0, (globalSpeed), 0);
        }
        else if(gameObject.CompareTag("Road"))
        {
            transform.Translate(0, 0, -(globalSpeed));
        }
        else 
        {
            transform.Translate(0, -(globalSpeed), 0);
        }
        
        
    }

    void DestroyElements()
    {
        if(gameObject.CompareTag("Road"))
        {
            if (transform.position.z < distanceDestroyRaod)
            {
                Destroy(gameObject);
            }
        }
        else if(transform.position.z < distanceDestroyAssets)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
