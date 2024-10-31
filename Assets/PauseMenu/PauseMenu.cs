using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static PauseMenu Instance;

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
        GameController.Instance.GuardarProgreso();
    }

    public void CargarPartida()
    {
        GameController.Instance.CargarProgreso();
        UIManager.Instance.MostrarEstadisticas(); // Actualizar UI
    }

    public void NuevaPartida()
    {
        SaveSystem.EliminarPartidaGuardada();
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        pauseMenuUI.SetActive(false);
        DayManager.Instance.ReiniciarPartida();
        DiaNocheManager.Instance.ReiniciarReloj();
        UIManager.Instance.MostrarEstadisticas(); // Actualizar UI
        Time.timeScale = 1f; // Reanudar el juego
    }
    

public void Salir()
{
    Time.timeScale = 1f; // Asegúrate de que el tiempo vuelve a la normalidad antes de salir.
    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); // Reemplaza la escena actual con el menú principal.
}

}
