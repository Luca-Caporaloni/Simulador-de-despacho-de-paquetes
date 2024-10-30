using UnityEngine;

public class CambiarVistas : MonoBehaviour
{

    public static CambiarVistas Instance;

    public Camera camara;
    public Transform[] posicionesVistas; // Posiciones para cada área
    private int indiceVistaActual = 0;
    private Vector2 inicioDeslizamiento;


    private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // Mantener el objeto a través de las escenas
    }
    else
    {
        Destroy(gameObject); // Si ya hay una instancia, destruir esta
    }
}



    void Update()
    {
        DetectarDeslizamiento();
    }

    void DetectarDeslizamiento()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inicioDeslizamiento = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 finDeslizamiento = (Vector2)Input.mousePosition - inicioDeslizamiento;
            if (finDeslizamiento.x > 50)
            {
                CambiarVista(-1);
            }
            else if (finDeslizamiento.x < -50)
            {
                CambiarVista(1);
            }
        }
    }

void CambiarVista(int direccion)
{
    indiceVistaActual += direccion;
    indiceVistaActual = Mathf.Clamp(indiceVistaActual, 0, posicionesVistas.Length - 1);
    camara.transform.position = posicionesVistas[indiceVistaActual].position;

    if (indiceVistaActual == 0)
    {
        AlmacenManager.Instance.ActualizarInventarioUI();
        MejoraManager.Instance.CerrarPanelMejoras();
        UIDetallesPaquete.Instance.OcultarDetalles();
    }
    else if (indiceVistaActual == 1)
    {
        // Asegúrate de que se está buscando el objeto correcto
        PaqueteInteract paqueteInteract = FindObjectOfType<PaqueteInteract>();
        if (paqueteInteract != null)
        {
            Debug.Log("PaqueteInteract encontrado. Inspeccionando paquete.");
            paqueteInteract.InspeccionarPaquete();
            
            // Aquí puedes necesitar obtener información sobre el paquete a inspeccionar
            Paquete paqueteInspeccionado = new Paquete(paqueteInteract.destino, paqueteInteract.peso, paqueteInteract.valor);
            UIDetallesPaquete.Instance.MostrarDetalles(paqueteInspeccionado, paqueteInteract.esFragil, paqueteInteract.horaEntrega);
        }
        else
        {
            Debug.LogError("No se encontró un objeto de tipo PaqueteInteract");
        }
        
        MejoraManager.Instance.CerrarPanelMejoras();
    }
    else if (indiceVistaActual == 2)
    {
        MejoraManager.Instance.AbrirPanelMejoras();
        UIDetallesPaquete.Instance.OcultarDetalles();
    }
}




}
