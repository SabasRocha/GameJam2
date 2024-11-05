using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public float distance = 0;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Almacenar la posici�n inicial del jugador
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular la distancia recorrida bas�ndose en la posici�n Z
        distance = Vector3.Distance(startPosition, transform.position);
    }

    public void AddScore(int points) 
    {
        score += points;
    }
}
