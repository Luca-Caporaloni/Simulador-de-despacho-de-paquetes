using UnityEngine;
using TMPro;

public class UIDetallesPaquete : MonoBehaviour
{
    public static UIDetallesPaquete Instance;

    public TextMeshProUGUI destinoText;
    public TextMeshProUGUI pesoText;
    public TextMeshProUGUI valorText;
    public TextMeshProUGUI fragilText;
    public TextMeshProUGUI horaEntregaText;
    public GameObject panel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Asigna la instancia
            DontDestroyOnLoad(gameObject); // No destruir al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe, destruye esta instancia
        }
    }

    public void MostrarDetalles(Paquete paquete, bool esFragil, string horaEntrega)
{
    destinoText.text = "Destino: " + paquete.destino;
    pesoText.text = "Peso: " + paquete.peso + " kg";
    valorText.text = "Valor: $" + Mathf.FloorToInt(paquete.valor); // Asegúrate de que sea un entero
    fragilText.text = esFragil ? "Frágil: Sí" : "Frágil: No";
    horaEntregaText.text = "Hora de entrega: " + horaEntrega;

    panel.SetActive(true); // Asegúrate de que el panel de detalles esté visible
}


    public void OcultarDetalles()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false); // Oculta solo el panel de detalles
        }
    }
}
