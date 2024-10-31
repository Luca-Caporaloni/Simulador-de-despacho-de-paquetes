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
        while (true)
        {
            yield return new WaitForSeconds(tiempoDeGeneracion);
            int cantidadPaquetes = Random.Range(1, 3); // Generar entre 1 y 2 paquetes

            for (int i = 0; i < cantidadPaquetes; i++)
            {
                if (inventario.Count < espacioMaximo)
                {
                    // Crear paquete y agregarlo al inventario
                    Paquete nuevoPaquete = new Paquete("Destino aleatorio", Random.Range(1f, 20f), Random.Range(10f, 200f));
                    inventario.Add(nuevoPaquete);
                    Debug.Log("Paquete recibido en el almacén.");
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
