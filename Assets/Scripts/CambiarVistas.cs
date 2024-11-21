using UnityEngine;


public class CambiarVistas : MonoBehaviour
{

    public static CambiarVistas Instance;

    public Camera camara;
    public Transform[] posicionesVistas; // Posiciones para cada área
    private int indiceVistaActual = 0;
    private Vector2 inicioDeslizamiento;

    private PaqueteInteract paqueteInteract; // Variable de instancia


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
    // Actualizar el índice de vista actual y cambiar la posición de la cámara
    indiceVistaActual += direccion;
    indiceVistaActual = Mathf.Clamp(indiceVistaActual, 0, posicionesVistas.Length - 1);
    camara.transform.position = posicionesVistas[indiceVistaActual].position;

    Debug.Log("Cambiando a vista " + indiceVistaActual);

    // Llamar a métodos específicos según la vista actual
    switch (indiceVistaActual)
    {
        case 0:
            ActivarVistaAlmacen();
            break;
        case 1:
            ActivarVistaPaquete();
            break;
        case 2:
            ActivarVistaMejoras();
            break;
    }
}

public int GetHabitacionActual()
    {
        return indiceVistaActual;
    }

private void ActivarVistaAlmacen()
{
    AlmacenManager.Instance.ActualizarInventarioUI();
    MejoraManager.Instance.CerrarPanelMejoras();
    UIDetallesPaquete.Instance.OcultarDetalles();

}

private void ActivarVistaPaquete()
{
    // Encuentra el objeto PaqueteInteract en la escena
    PaqueteInteract paqueteInteract = FindObjectOfType<PaqueteInteract>();

    Paquete paquete = new Paquete(paqueteInteract.destino, paqueteInteract.peso, paqueteInteract.valor);
    // Verificar que paqueteInteract no sea null


        // Llamar a MostrarDetalles con los parámetros requeridos
        UIDetallesPaquete.Instance.MostrarDetalles(paquete, paqueteInteract.esFragil, paqueteInteract.horaEntrega);
        // Cerrar el panel de mejoras
        MejoraManager.Instance.CerrarPanelMejoras();


}


private void ActivarVistaMejoras()
{
    MejoraManager.Instance.AbrirPanelMejoras();
    UIDetallesPaquete.Instance.OcultarDetalles();
}






}
