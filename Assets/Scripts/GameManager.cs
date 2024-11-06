using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public GameObject dulcePrefab; // Asigna tu prefab de dulce aqu�
    public float spawnInterval = 2f; // Intervalo de generaci�n
    public float spawnRangeX = 3.0f; // Rango en X para la aparici�n
    public GameObject nino, adolescente, adulto, fantasma;
    public ParticleSystem explosionParticle;
    public AudioClip levelClip, transformClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;   
        }
    }
    private void Start()
    {
        
       AudioManager.Instance.PlayMusic(levelClip, true);
        
    }

    void Update()
    {
  
    }

    private void SpawnDulce()
    {
        // Generar un dulce en una posici�n aleatoria en el eje X y en la posici�n Z del jugador
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, transform.position.z + 10f); // Ajusta la posici�n Z

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
                AudioManager.Instance.PlaySFX(transformClip);
                adolescente.transform.position = personajeActual.transform.position;
                Instantiate(explosionParticle, personajeActual.transform.position, explosionParticle.transform.rotation);
                adolescente.SetActive(true);
                adolescente.GetComponent<PlayerMovement>().ActCarril(nino.GetComponent<PlayerMovement>().carrilActual);
                break;
            case "adulto":
                AudioManager.Instance.PlaySFX(transformClip);
                adulto.transform.position = personajeActual.transform.position;
                Instantiate(explosionParticle, personajeActual.transform.position, explosionParticle.transform.rotation);
                adulto.GetComponent<PlayerMovement>().ActCarril(adolescente.GetComponent<PlayerMovement>().carrilActual);
                adulto.SetActive(true);
                break;
            case "muerto":
                AudioManager.Instance.PlaySFX(transformClip);
                fantasma.transform.position = personajeActual.transform.position;
                Instantiate(explosionParticle, personajeActual.transform.position, explosionParticle.transform.rotation);
                fantasma.GetComponent<PlayerMovement>().ActCarril(adulto.GetComponent<PlayerMovement>().carrilActual);
                fantasma.SetActive(true);   
                break;
        }
        GameObject.FindAnyObjectByType<SpawnObjManager>().SetPlayer();

      

    }
}
