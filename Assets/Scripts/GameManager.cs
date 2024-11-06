using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public GameObject dulcePrefab; // Asigna tu prefab de dulce aqu�
    public float spawnInterval = 2f; // Intervalo de generaci�n
    public float spawnRangeX = 3.0f; // Rango en X para la aparici�n
    public GameObject adolescente, adulto, anciano, fantasma;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;   
        }
    }
    private void Start()
    {
      //  InvokeRepeating("SpawnDulce", 0, spawnInterval);
    }

    private void SpawnDulce()
    {
        // Generar un dulce en una posici�n aleatoria en el eje X y en la posici�n Z del jugador
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, transform.position.z + 10f); // Ajusta la posici�n Z

        Instantiate(dulcePrefab, spawnPosition, Quaternion.identity);
    }
    public void CambiarPersonaje()
    {
        GameObject personajeActual = GameObject.FindAnyObjectByType<PlayerMovement>().gameObject;
        PlayerMovement playerMovement = GameObject.FindAnyObjectByType<PlayerMovement>();
        Vector3 position = personajeActual.transform.position;
        personajeActual.SetActive(false);
        GameObject personajeCreado = Instantiate(adolescente, position, Quaternion.identity);
        personajeCreado.GetComponent<PlayerMovement>().posCarrilIzq = playerMovement.posCarrilIzq; 
        personajeCreado.GetComponent<PlayerMovement>().posCarrilCen = playerMovement.posCarrilCen; 
        personajeCreado.GetComponent<PlayerMovement>().posCarrilDer = playerMovement.posCarrilDer; 

    }
}
