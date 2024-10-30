using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI dineroText;
    public TextMeshProUGUI paquetesEnviadosText;
    public TextMeshProUGUI currentDayText;
    public TextMeshProUGUI horaText; // Asegúrate de tener un TextMeshPro para la hora

    private void Awake()
    {
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

    

    public void MostrarEstadisticas()
    {
        dineroText.text = "Dinero ganado: $" + DayManager.Instance.dineroGanado;
        paquetesEnviadosText.text = "Paquetes enviados: " + DayManager.Instance.paquetesEnviados;
        currentDayText.text = "Día: " + DayManager.Instance.currentDay;
    }

    public void ActualizarHoraUI(string hora)
{
    if (horaText != null)
    {
        horaText.text = hora;
    }
    else
    {
        Debug.LogWarning("Referencia a horaText no asignada en UIManager.");
    }
}
}
