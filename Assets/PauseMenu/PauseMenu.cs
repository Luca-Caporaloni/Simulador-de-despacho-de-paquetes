using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reanudar el juego
    }

    public void Guardar()
    {
        // Implementar guardado desde el menú de pausa
        GameController.Instance.GuardarProgreso();
    }

    public void Salir()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo vuelve a la normalidad
        SceneManager.LoadScene("MainMenu"); // Volver al menú principal
    }
}
