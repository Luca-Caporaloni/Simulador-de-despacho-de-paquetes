using UnityEngine;

public class Reloj : MonoBehaviour
{
    public int horaActual = 6;   // Hora de inicio (6:00 AM)
    public int minutosActual = 0; // Minutos de inicio
    public float tiempoEscala = 1f;  // Velocidad a la que avanza el tiempo del juego

    private float tiempoAcumulado = 0f;

    public static Reloj Instance;

    private void Awake()
    {
        // Patrón Singleton para que solo haya una instancia del reloj
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
        }
    }

    private void Update()
    {
        tiempoAcumulado += Time.deltaTime * tiempoEscala;

        // Cada segundo (o según tu configuración), avanza el tiempo
        if (tiempoAcumulado >= 1f)
        {
            AvanzarMinuto();
            tiempoAcumulado = 0f; // Reiniciar el acumulador
        }
    }

    private void AvanzarMinuto()
    {
        minutosActual += 2; // Avanzar en intervalos de 2 minutos

        if (minutosActual >= 60)
        {
            minutosActual = 0; // Reiniciar minutos
            horaActual++; // Aumentar la hora

            // Verifica si el día debe reiniciarse
            if (horaActual > 21) // Si pasa las 21:00
            {
                horaActual = 6; // Reiniciar a las 6:00 AM
                DayManager.Instance.IniciarNuevoDia(); // Iniciar un nuevo día
            }
        }

        // Actualizar la UI con la hora formateada
        UIManager.Instance.ActualizarHoraUI(FormatoHora());
    }

    private string FormatoHora()
    {
        return horaActual.ToString("00") + ":" + minutosActual.ToString("00"); // Formato 24 horas
    }
}
