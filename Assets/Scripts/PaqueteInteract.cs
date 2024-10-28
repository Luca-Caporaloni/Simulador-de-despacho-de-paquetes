using UnityEngine;

public class PaqueteInteract : MonoBehaviour
{
    public int costoPaquete; // Precio de envío del paquete

    public void DespacharPaquete()
    {
        DayManager.Instance.PaqueteDespachado(costoPaquete);
        Destroy(gameObject); // Eliminar el paquete una vez despachado
    }
}
