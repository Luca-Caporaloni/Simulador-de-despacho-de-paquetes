using UnityEngine;
using UnityEngine.UI;

public class FormularioDespacho : MonoBehaviour
{

    public float valor; // Añade el campo de valor aquí

    public static FormularioDespacho Instance;


    public GameObject formularioPanel; // Panel del formulario
    public InputField direccionInput;  // Campo de entrada para dirección
    public Button enviarButton;         // Botón para enviar el formulario

    private void Start()
    {
        // Asegúrate de que el formulario esté oculto al inicio
        formularioPanel.SetActive(false);
        
        // Agrega el listener para el botón
        enviarButton.onClick.AddListener(EnviarFormulario);
    }

    public void AbrirFormulario()
    {
        formularioPanel.SetActive(true); // Mostrar el formulario
    }

        public void EnviarFormulario()
{
    // Obtiene la dirección del campo de entrada y la normaliza
    string direccion = NormalizarTexto(direccionInput.text);

    // Obtiene el paquete del almacén para inspección
    Paquete paquete = AlmacenManager.Instance.ObtenerPaqueteParaInspeccion();

    // Verifica si el paquete existe
    if (paquete != null)
    {
        string destinoPaqueteNormalizado = NormalizarTexto(paquete.destino);

        // Compara la dirección ingresada con el destino del paquete
        if (direccion == destinoPaqueteNormalizado)
        {
            Debug.Log("Paquete despachado correctamente a: " + direccion);
            int costoPaquete = Mathf.RoundToInt(paquete.valor); // Usamos el valor del paquete
            DayManager.Instance.PaqueteDespachado(costoPaquete);
            formularioPanel.SetActive(false); // Oculta el formulario
        }
        else
        {
            Debug.LogWarning("Dirección incorrecta.");
            DayManager.Instance.RegistrarMulta(50, "Destino incorrecto");
        }
    }
    else
    {
        Debug.LogWarning("No hay paquete disponible para inspección.");
    }

    // Actualiza las estadísticas en la UI
    UIManager.Instance.MostrarEstadisticas();
}

private string NormalizarTexto(string texto)
{
    if (string.IsNullOrEmpty(texto)) return ""; // Evita errores con cadenas vacías
    return texto.Trim().ToLower().Replace("\n", "").Replace("\r", ""); // Limpia espacios y caracteres invisibles
}


    public void OcultarFormulario()
    {
        formularioPanel.SetActive(false);
    }

}
