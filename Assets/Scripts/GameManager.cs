using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public GameObject dulcePrefab; // Asigna tu prefab de dulce aquí
    public float spawnInterval = 2f; // Intervalo de generación
    public float spawnRangeX = 3.0f; // Rango en X para la aparición
    public GameObject nino, adolescente, adulto, fantasma;
    public ParticleSystem explosionParticle;

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

    void Update()
    {
  
    }

    private void SpawnDulce()
    {
        // Generar un dulce en una posición aleatoria en el eje X y en la posición Z del jugador
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, transform.position.z + 10f); // Ajusta la posición Z

        Instantiate(dulcePrefab, spawnPosition, Quaternion.identity);
    }
    public void CambiarPersonaje(string Personaje)
    {
        GameObject personajeActual = GameObject.FindAnyObjectByType<PlayerMovement>().gameObject;
        PlayerMovement playerMovement = GameObject.FindAnyObjectByType<PlayerMovement>();
        Vector3 position = personajeActual.transform.position;
        personajeActual.SetActive(false);

        switch (Personaje)
        {
            case "adolecente":
                adolescente.transform.position = personajeActual.transform.position;
                Instantiate(explosionParticle, personajeActual.transform.position, explosionParticle.transform.rotation);
                adolescente.SetActive(true);
                adolescente.GetComponent<PlayerMovement>().ActCarril(nino.GetComponent<PlayerMovement>().carrilActual);
                break;
            case "adulto":
                adulto.transform.position = personajeActual.transform.position;
                Instantiate(explosionParticle, personajeActual.transform.position, explosionParticle.transform.rotation);
                adulto.GetComponent<PlayerMovement>().ActCarril(adolescente.GetComponent<PlayerMovement>().carrilActual);
                adulto.SetActive(true);
                break;
            case "muerto":
                fantasma.transform.position = personajeActual.transform.position;
                Instantiate(explosionParticle, personajeActual.transform.position, explosionParticle.transform.rotation);
                fantasma.GetComponent<PlayerMovement>().ActCarril(adulto.GetComponent<PlayerMovement>().carrilActual);
                fantasma.SetActive(true);   
                break;
        }
        GameObject.FindAnyObjectByType<SpawnObjManager>().SetPlayer();

      

    }
}
