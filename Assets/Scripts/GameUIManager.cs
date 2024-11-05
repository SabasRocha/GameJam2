using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Collections.Specialized.BitVector32;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI globalScoreText;
    public TextMeshProUGUI messageText; // Referencia al texto para mensajes de crecimiento
    public Slider distanceProgressBar;
    

    private float tiempoF;
    private int globalScore;

    private int phase = 0; // Fase actual (1: Adolescente, 2: Adulto, 3: Anciano)
    private int phaseMaxTime; // Tiempo máximo para cada fase (20, 60, 120)
    private int phaseMinValue; // Valor mínimo de la barra para cada fase (0, 21, 61)

    void Start()
    {
        SetPhaseValues(1); // Inicializa la fase 1 (adolescente)
        distanceProgressBar.value = 0;
        messageText.gameObject.SetActive(false); // Oculta el mensaje al inicio
    }

    void Update()
    {                                                 
        if (globalScore < phaseMaxTime)
        {
            distanceProgressBar.value = globalScore; // La barra refleja el progreso del tiempo en cada fase
        }

        if (globalScore >= phaseMaxTime)
        {
            OnPhaseReached();
        }
    }

    private void FixedUpdate()
    {
        GlobalScore();
    }

    public void GlobalScore()
    {
        /*tiempoF += Time.deltaTime;
        globalScore = (int)(tiempoF * 10);
        globalScoreText.text = "Time: " + Mathf.CeilToInt(globalScore).ToString();*/

        tiempoF += 1 * Time.deltaTime;
        globalScore = (int)(tiempoF);
        globalScoreText.text = "Time: " + Mathf.CeilToInt(globalScore).ToString();
    }

    void OnPhaseReached()
    {
        if (phase >= 4)
        {
            return; // No incrementar más fases
        }

        ShowPhaseMessage();
        // Incrementar fase
        phase++;
        // Establecer valores para la siguiente fase
        SetPhaseValues(phase);
    }

    private void ShowPhaseMessage()
    {
        messageText.gameObject.SetActive(true); // Eliminar la condición temporalmete

        // Selecciona el mensaje adecuado según la fase
        switch (phase)
        {
            case 1:
                messageText.text = "Very good, you managed to grow up, you are a teenager";                
                break;
            case 2:
                messageText.text = "You are progressing, you are an adult";                
                break;
            case 3:
                messageText.text = "Fantastic, you are a very skilled older adult.";                
                break;
            default:
                break;
        }

        // Oculta el mensaje después de unos segundos (ajustar tiempo si es necesario)
        Invoke("HideMessage", 4f);
    }


    private void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }

    private void SetPhaseValues(int currentPhase)
    {
        // Define los valores de fase
        switch (currentPhase)
        {
            case 1:
                phaseMaxTime = 10;
                phaseMinValue = 0;
                break;
            case 2:
                phaseMaxTime = 20;
                phaseMinValue =11;
                break;
            case 3:
                phaseMaxTime = 30;
                phaseMinValue =21;
                break;
        }

        distanceProgressBar.minValue = phaseMinValue;
        distanceProgressBar.maxValue = phaseMaxTime;
        distanceProgressBar.value = phaseMinValue; // Reinicia la barra al valor mínimo de la nueva fase
    }
}
