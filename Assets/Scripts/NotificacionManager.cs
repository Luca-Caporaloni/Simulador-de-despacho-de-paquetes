using UnityEngine;
using TMPro;

public class NotificacionManager : MonoBehaviour
{
    public static NotificacionManager Instance;

    public GameObject panelNotificacion;  // Panel que contiene la notificación
    public TextMeshProUGUI mensajeText;   // Texto de la notificación

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para mostrar la notificación
    public void MostrarNotificacion(string mensaje, float duracion = 3f)
    {
        mensajeText.text = mensaje;
        panelNotificacion.SetActive(true);
        Invoke(nameof(OcultarNotificacion), duracion);  // Ocultar después de una duración
    }

    private void OcultarNotificacion()
    {
        panelNotificacion.SetActive(false);
    }
}
