using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public DayManager dayManager;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI paquetesEnviadosText;
    public TextMeshProUGUI paquetesEntregadosText;
    public TextMeshProUGUI dineroGanadoText;

    private void Update()
    {
        MostrarEstadisticas();
    }

    public void MostrarEstadisticas()
    {
        dayText.text = "Día: " + dayManager.currentDay;
        paquetesEnviadosText.text = "Paquetes Enviados: " + dayManager.paquetesEnviados;
        paquetesEntregadosText.text = "Paquetes Entregados: " + dayManager.paquetesEntregados;
        dineroGanadoText.text = "Dinero Ganado: $" + dayManager.dineroGanado;
    }
}
