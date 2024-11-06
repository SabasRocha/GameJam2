using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class MoveForwardObj : MonoBehaviour
{
    public static float movementZ, speed = 50f, speedIncrease = 0.05f, globalSpeed = 0f, distanceDestroyRaod = -1791, distanceDestroyAssets = -10;
    private bool Destruido = false;
    private Rigidbody candyRB;
    Transform childGameObject;
    public float globalSpeedPub;

    void Start()
    {
        transform.position = transform.position;
        if(gameObject.CompareTag("Candy") && Destruido == false)
        {
            candyRB = GetComponentInChildren<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(globalSpeed);
    }

    private void FixedUpdate()
    {
       
       MoveAndRotateElements();
       DestroyElements();
       GlobalVelocity();
       
    }

    public void GlobalVelocity()
    {
        speed += speedIncrease * Time.deltaTime;
        globalSpeed = Mathf.Min(3, (speed * Time.deltaTime));
    }

    void MoveAndRotateElements()
    {
        transform.Translate(0, 0, -(globalSpeed));

        if (gameObject.CompareTag("Candy") && candyRB != null)
        {
            candyRB.AddTorque(0, 15, 0, ForceMode.Force);
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

    private void OnDestroy()
    {
        Destruido = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }

    public static void ReiniciarVariables()
    {
        // Reiniciar las variables estáticas aquí
        speed = 50f;
        speedIncrease = 0.05f;
        globalSpeed = 0f;
        distanceDestroyRaod = -1791;
        distanceDestroyAssets = -10;
    }

}
