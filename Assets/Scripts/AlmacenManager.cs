using System.Collections.Generic;
using UnityEngine;

public class AlmacenManager : MonoBehaviour
{
    public static AlmacenManager Instance;
    public int espacioMaximo = 10;
    private List<Paquete> inventario = new List<Paquete>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RecibirPaquete(Paquete nuevoPaquete)
    {
        if (inventario.Count < espacioMaximo)
        {
            inventario.Add(nuevoPaquete);
            Debug.Log("Paquete recibido en el almacén.");
        }
        else
        {
            Debug.Log("Almacén lleno. No se pueden recibir más paquetes.");
        }
    }

    public Paquete ObtenerPaqueteParaInspeccion()
    {
        if (inventario.Count > 0)
        {
            Paquete paquete = inventario[0];
            inventario.RemoveAt(0);
            return paquete;
        }
        return null;
    }

    // Método para actualizar la UI del inventario
    public void ActualizarInventarioUI()
    {
        Debug.Log("Actualizando UI del inventario.");
    }
}
