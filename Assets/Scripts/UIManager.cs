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

    public TextMeshProUGUI relojText;

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

     private void Start()
    {
        // Opcional: inicializar el reloj con el tiempo actual
        ActualizarHoraUI("08:00"); // Hora inicial
    }
    

    public void MostrarEstadisticas()
    {
        dineroText.text = "Dinero ganado: $" + DayManager.Instance.dineroGanado;
        paquetesEnviadosText.text = "Paquetes enviados: " + DayManager.Instance.paquetesEnviados;
        currentDayText.text = "Día: " + DayManager.Instance.currentDay;
    }

    public void ActualizarHoraUI(string hora)
    {
        if (relojText != null)
        {
            relojText.text = hora; // Actualizar el texto del reloj
        }
        else
        {
            Debug.LogWarning("relojText no está asignado en UIManager.");
        }
    }
}

