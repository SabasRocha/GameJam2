using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI distanceText;
    public GameObject gameOverPanel;
    private PlayerScore player; // Asume que los puntos están en PlayerController
    

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScore>();
        if (player == null)
            Debug.LogError("PlayerScore no encontrado en el objeto Player.");

    }

    void Update()
    {
        if (player != null)
        {
            // Actualiza el puntaje
            scoreText.text = "Score: " + player.score;

            // Actualiza la distancia desde PlayerScore
            distanceText.text = "Distance: " + Mathf.FloorToInt(player.distance) + "m";
        }
        
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Activa el panel de Game Over
    }
}
