using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class AlmacenManager : MonoBehaviour
{
    public static AlmacenManager Instance;
    public int espacioMaximo = 10;
    private List<Paquete> inventario = new List<Paquete>();

    

    
    public GameObject paquetePrefab; // Prefab del paquete
    public float tiempoDeGeneracion = 30f; // Tiempo en segundos para generar paquetes

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

    private void Start()
    {
        StartCoroutine(GenerarPaquetes());
    }

    private IEnumerator GenerarPaquetes()
{
    string[] destinos = { "Nueva York", "Londres", "París", "Tokio", "Sídney" }; // Your predefined destinations

    while (true)
    {
        yield return new WaitForSeconds(tiempoDeGeneracion);

        int cantidadPaquetes = Random.Range(1, 3); // Generate between 1 and 2 packages
        for (int i = 0; i < cantidadPaquetes; i++)
        {
            if (inventario.Count < espacioMaximo)
            {
                // Randomly select a destination from the array
                string destinoSeleccionado = destinos[Random.Range(0, destinos.Length)];

                // Create a package and add it to the inventory
                Paquete nuevoPaquete = new Paquete(destinoSeleccionado, Random.Range(1f, 20f), Random.Range(10f, 200f));
                inventario.Add(nuevoPaquete);

                Debug.Log($"Paquete generado: Destino={nuevoPaquete.destino}, Peso={nuevoPaquete.peso}kg, Valor={nuevoPaquete.valor}");

                // Update the UI with the details of the most recent package
                UIDetallesPaquete.Instance.MostrarDetalles(nuevoPaquete, nuevoPaquete.esFragil, nuevoPaquete.horaEntrega);
            }
            else
            {
                Debug.Log("Almacén lleno. No se pueden recibir más paquetes.");
                break;
            }
        }
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
        Debug.Log($"Paquete obtenido para inspección: Destino={paquete.destino}");
        return paquete;
    }
    else
    {
        Debug.LogWarning("El inventario está vacío. No se puede obtener un paquete.");
    }
    return null;
}


    // Método para actualizar la UI del inventario
    public void ActualizarInventarioUI()
    {
        Debug.Log("Actualizando UI del inventario.");
    }
}
