using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioManager audioManager;

    void Start()
    {
        // Buscar el AudioManager persistente
        audioManager = AudioManager.Instance;

        if (volumeSlider == null)
        {
            volumeSlider = FindObjectOfType<Slider>();
        }

        if (audioManager != null && volumeSlider != null)
        {
            // Restaura el volumen guardado o usa el valor predeterminado
            float savedVolume = PlayerPrefs.GetFloat("Volume", 0.4f); // Ajusta el valor por defecto según lo que necesites
            volumeSlider.value = savedVolume;

            // Ajusta el volumen de la música y los efectos
            audioManager.musicSource.volume = savedVolume;
            audioManager.effectsSource.volume = savedVolume;

            // Añadir listener para cuando el valor del slider cambie
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float volume)
    {
        if (audioManager != null)
        {
            audioManager.musicSource.volume = volume;
            audioManager.effectsSource.volume = volume;

            // Guarda el volumen ajustado para la próxima vez
            PlayerPrefs.SetFloat("Volume", volume);
        }
    }

    void OnDestroy()
    {
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(SetVolume);
        }
    }
}



