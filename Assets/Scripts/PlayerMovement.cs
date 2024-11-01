using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private GameUIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<GameUIManager>();
    }

    
    void Update()
    {
        
    }

    // se añade una función para detectar colisiones con objetos etiquetados como "Obstacle".
    // asegurar de que los objetos obstáculos tengan el tag "Obstacle"
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (uiManager != null)
            {
                uiManager.ShowGameOver();
                Time.timeScale = 0;
            }
            else
            {
                Debug.LogError("GameUIManager no asignado en PlayerMovement.");
            }
        }
    }
}
