using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CinematicEnd : MonoBehaviour
{
    public PlayableDirector director;

    void Start()
    {
        // Obtiene el componente PlayableDirector
        director = GetComponent<PlayableDirector>();

        // Añade un listener para cuando termina el Timeline
        director.stopped += OnCinematicEnd;
    }

    void OnCinematicEnd(PlayableDirector pd)
    {
        // Cambia a la escena del menú principal cuando termine la cinemática
        if (pd == director)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void OnDestroy()
    {
        // Elimina el listener al destruir el objeto para evitar errores
        if (director != null)
        {
            director.stopped -= OnCinematicEnd;
        }
    }
}


