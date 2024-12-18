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

    public PaqueteInteract paqueteInteract;


 private void Start()
{
    panel.SetActive(false); // Oculta solo el panel de detalles 
   
    //paqueteInteract.GenerarDetallesAleatorios(); // Generar detalles aleatorios solo si la instancia existe
    
}

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
    if (paquete == null)
    {
        Debug.LogError("Paquete es nulo al intentar mostrar detalles.");
        return;
    }

    Debug.Log($"Paquete recibido para mostrar detalles: Destino={paquete.destino}, Peso={paquete.peso}, Valor={paquete.valor}, Hora={horaEntrega}");

    if (destinoText == null || pesoText == null || valorText == null || fragilText == null || horaEntregaText == null)
    {
        Debug.LogError("Una o más referencias de TextMeshProUGUI no están asignadas.");
        return;
    }

    destinoText.text = "Destino: " + paquete.destino;
    pesoText.text = "Peso: " + paquete.peso.ToString("0.00") + " kg";
    valorText.text = "Valor: $" + Mathf.FloorToInt(paquete.valor);
    fragilText.text = esFragil ? "Frágil: Sí" : "Frágil: No";
    horaEntregaText.text = "Hora de entrega: " + horaEntrega;

    panel.SetActive(true); // Asegúrate de que el panel esté activo
}





    public void OcultarDetalles()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false); // Oculta solo el panel de detalles
        }
    }
}
