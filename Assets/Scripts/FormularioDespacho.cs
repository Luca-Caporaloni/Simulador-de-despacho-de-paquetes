using UnityEngine;
using UnityEngine.UI;

public class FormularioDespacho : MonoBehaviour
{

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

        // Aquí debes crear una instancia de Paquete
        // Por ejemplo, puedes definir otros parámetros como peso y valor de forma estática o aleatoria
        Paquete nuevoPaquete = new Paquete(direccion, Random.Range(1f, 20f), Random.Range(10f, 100f)); // Cambia esto según tu lógica

        // Ahora pasa el paquete al método DespacharPaquete
        DayManager.Instance.DespacharPaquete(nuevoPaquete);

        Debug.Log("Paquete despachado a: " + direccion);
        formularioPanel.SetActive(false); // Ocultar el formulario después de enviar
        UIManager.Instance.MostrarEstadisticas();
    }

    public void OcultarFormulario()
    {
        formularioPanel.SetActive(false);
    }

}
