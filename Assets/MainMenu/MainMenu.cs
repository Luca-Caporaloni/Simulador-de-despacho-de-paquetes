using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("MainScene"); // Cargar la escena principal
    }

    public void NuevaPartida()
    {
        SaveSystem.EliminarPartidaGuardada(); // Elimina los datos de guardado
        SceneManager.LoadScene("MainScene"); // Carga una partida limpia
    }

    public void Salir()
    {
        Application.Quit();
    }
}
