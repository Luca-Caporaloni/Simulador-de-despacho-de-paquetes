using UnityEngine;

public class DiaNocheManager : MonoBehaviour
{
    public static DiaNocheManager Instance;

    public float tiempoDelDia; // Tiempo actual del día (0 a 24)
    public float duracionDelDia = 1200f; // Duración del día en segundos (20 minutos)
    public float incrementoTiempo = 1f; // Aumentar tiempo por segundo

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

    private void Update()
    {
        // Aumentar tiempo
        tiempoDelDia += Time.deltaTime * (incrementoTiempo * (24 / duracionDelDia));
        
        // Ciclo día y noche
        if (tiempoDelDia >= 24)
        {
            tiempoDelDia = 0; // Reiniciar el día
            DayManager.Instance.IniciarNuevoDia(); // Iniciar un nuevo día
        }

        // Calcular la hora en el rango de 8 AM a 6 PM
        float horaJuego = 8 + (tiempoDelDia * (10f / 24f)); // Mapeo de 0 a 24 a 8 AM - 6 PM
        
        // Formatear la hora para el UI
        string horaActual = Mathf.Floor(horaJuego).ToString("00") + ":" + Mathf.Floor((horaJuego % 1) * 60).ToString("00");
        UIManager.Instance.ActualizarHoraUI(horaActual);
    }

    public void ReiniciarReloj()
    {
        tiempoDelDia = 0;
    }
}
