using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Collections.Specialized.BitVector32;


public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI globalScoreText;
    public Slider distanceProgressBar;
    
    public float maxDistance = 20f;

    private float tiempoF;
    private int globalScore;

    void Start()
    {
        distanceProgressBar.maxValue = maxDistance;
        distanceProgressBar.value = 0;
    }

    void Update()
    {
        // Sincroniza el valor de la barra con el tiempo global
        if (globalScore < maxDistance)
        {
            distanceProgressBar.value = globalScore; // La barra refleja el progreso del tiempo
        }

        // Verifica si tanto la barra como el tiempo han alcanzado el valor máximo
        if (globalScore >= maxDistance && distanceProgressBar.value >= maxDistance)
        {
            OnMaxReached();
        }
    }

    private void FixedUpdate()
    {
        GlobalScore();
    }

    public void GlobalScore()
    {
        tiempoF += Time.deltaTime;
        globalScore = (int)(tiempoF * 10);  // Incrementa el tiempo y convierte a un valor entero
        globalScoreText.text = "Time: " + Mathf.CeilToInt(globalScore).ToString();
    }

    private void OnMaxReached()
    {
        // Acción cuando ambos alcanzan el valor máximo
        Debug.Log("¡La barra y el tiempo alcanzaron el máximo!");
        // Aquí puedes agregar el comportamiento especial que necesitas
    }
}
