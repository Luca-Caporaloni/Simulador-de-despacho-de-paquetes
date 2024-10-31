using System.Collections;
using UnityEngine;
using TMPro; // Importar TextMesh Pro
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject panelTutorial; // Panel que muestra los mensajes
    public TextMeshProUGUI tutorialText; // Texto dentro del panel (TextMeshPro)
    public float typingSpeed = 0.5f; // Velocidad de escritura

    private int currentMessageIndex = 0;
    private bool isPanelVisible = false;
    private bool isTutorialActive = true;
    private Coroutine typingCoroutine;

    // Mensajes del tutorial
    private string[] tutorialMessages = {
        "Bienvenido al simulador de Despachante de Cajas!!",
        "Empecemos con algo simple...Mantén apretado el Botón IZQ del mouse y arrastra hacia la Izquierda...",
        "Bien!! Esta es la Habitación de Inspección de Paquetes.",
        "Ves el formulario a la derecha del paquete? Bueno, esos son los datos de la caja...",
        "Dependiendo del peso que tenga, el valor va a ser mayor o menor...",
        "El valor del paquete es la ganancia que tendrás al despachar el paquete...",
        "Pero ten cuidado, que si pones la dirección de envío incorrecta se te penalizará y perderás ganancias...",
        "Bueno, sabiendo eso presiona Despachar y pon la dirección de envío y  entrega...",
        "Bien!!, pasemos a la siguiente sala (Arrastra el Mouse hacia la IZQ manteniendo apretado el Botón IZQ)...",
        "Ahora, estás en la sala de mejoras...",
        "El panel de tu Izquierda son las opciones de mejora que tienes disponibles...",
        "Preciona alguna mejora...",
        "Uh!! Es cierto...no tienes el suficiente dinero para comprar una mejora...",
        "Vuelve a Inspección y despacha algunos más...",
        "Ya tienes el dinero suficiente!! Compra una mejora...",
        "LISTO!! Finalisaste el tutorial...Eso sería lo básico para que empiezes a jugar...Disfruta :)"
    };

    void Start()
    {
        ShowMessage(); // Mostrar el primer mensaje
        DisablePlayerMovement(); // Desactivar movimiento al inicio del tutorial
    }

    void Update()
    {
        if (isTutorialActive)
        {
            if (Input.GetKeyDown(KeyCode.Return)) // Si se presiona Enter
            {
                if (isPanelVisible)
                {
                    HideMessage(); // Ocultar el panel
                }
                else
                {
                    ShowMessage(); // Mostrar el siguiente mensaje
                }
            }

            if (currentMessageIndex == 4 && Input.GetKeyDown(KeyCode.Space)) // Presionar Space para el último mensaje
            {
                ShowMessage(); // Mostrar el quinto mensaje
            }
        }
    }

    // Mostrar el mensaje actual letra por letra
    void ShowMessage()
    {
        if (currentMessageIndex < tutorialMessages.Length)
        {
            panelTutorial.SetActive(true);
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine); // Detener la corrutina si ya estaba en curso
            }
            typingCoroutine = StartCoroutine(TypeText(tutorialMessages[currentMessageIndex])); // Iniciar efecto de escritura
            isPanelVisible = true;
            DisablePlayerMovement(); // Desactivar movimiento del jugador
        }
        else
        {
            isTutorialActive = false; // Finalizar el tutorial
            HideMessage(); // Ocultar el panel al terminar
        }
    }

    // Corrutina para mostrar el texto letra por letra
    IEnumerator TypeText(string message)
    {
        tutorialText.text = "";
        foreach (char letter in message.ToCharArray())
        {
            tutorialText.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Esperar entre letras
        }
    }

    // Ocultar el panel de tutorial
    void HideMessage()
    {
        panelTutorial.SetActive(false);
        isPanelVisible = false;
        currentMessageIndex++; // Pasar al siguiente mensaje
        EnablePlayerMovement(); // Reactivar movimiento del jugador
    }

    // Desactivar movimiento del jugador usando el script "movement"
    void DisablePlayerMovement()
    {

    }

    // Reactivar movimiento del jugador
    void EnablePlayerMovement()
    {

    }
}
