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

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void MostrarEstadisticas()
    {
        dineroText.text = "Dinero ganado: $" + DayManager.Instance.dineroGanado;
        paquetesEnviadosText.text = "Paquetes enviados: " + DayManager.Instance.paquetesEnviados;
        currentDayText.text = "Día: " + DayManager.Instance.currentDay;
    }
}
