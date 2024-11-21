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
            string direccion = direccionInput.text; // Obtiene la dirección del campo de entrada

            // Ahora pasa el paquete al método DespacharPaquete
            Paquete paquete = AlmacenManager.Instance.ObtenerPaqueteParaInspeccion();
    if (paquete != null && direccion == paquete.destino)
    {
        Debug.Log("Paquete despachado a: " + direccion);
        int costoPaquete = Mathf.RoundToInt(valor);
        DayManager.Instance.PaqueteDespachado(costoPaquete);
        formularioPanel.SetActive(false);
    }
    else
    {
        Debug.LogWarning("Dirección incorrecta.");
        DayManager.Instance.RegistrarMulta(50, "Destino incorrecto");
    }
        UIManager.Instance.MostrarEstadisticas();
    }

    public void OcultarFormulario()
    {
        formularioPanel.SetActive(false);
    }

}
