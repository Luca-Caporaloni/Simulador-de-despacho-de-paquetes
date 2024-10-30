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

    private void Awake()
    {
        // Asegúrate de que la instancia sea la correcta
        if (Instance == null)
        {
            Instance = this; // Asigna esta instancia
            DontDestroyOnLoad(gameObject); // No destruir al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
        }
    }

    public void MostrarDetalles(Paquete paquete, bool esFragil, string horaEntrega)
    {
        destinoText.text = "Destino: " + paquete.destino;
        pesoText.text = "Peso: " + paquete.peso + " kg";
        valorText.text = "Valor: $" + paquete.valor;
        fragilText.text = esFragil ? "Frágil: Sí" : "Frágil: No";
        horaEntregaText.text = "Hora de entrega: " + horaEntrega;
        
        gameObject.SetActive(true); // Asegurar que el panel de detalles esté visible
    }

    public void OcultarDetalles()
    {
        destinoText.text = "";
        pesoText.text = "";
        valorText.text = "";
        fragilText.text = "";
        horaEntregaText.text = "";

        gameObject.SetActive(false); // Ocultar el panel de detalles
    }
}
