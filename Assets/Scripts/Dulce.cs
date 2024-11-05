using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dulce : MonoBehaviour
{
    public float turnSpeed = 90.0f;
    public float speed = 5.0f;
    public int scoreValue = 1; // Valor del dulce que se sumará al puntaje

    
    void Start()
    {
        

    }

    
    void Update()
    {
        // Rotar el dulce
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);

        //Mover el dulce hacia atrás
        transform.Translate(Vector3.back * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        //Primero debemos verificar que el objeto con el que chocamos sea el player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dulce colisiona con el player");
            // Obtener el script PlayerScore del jugador
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                // Sumar puntos al puntaje del jugador
                playerScore.AddScore(scoreValue);
                Debug.Log("Puntaje aumentado" + playerScore.score);
            }

            // Destruir este dulce
            Destroy(gameObject);
        }
    }
}
