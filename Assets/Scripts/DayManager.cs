using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
   public static DayManager Instance;

    public int currentDay = 1;
    public int paquetesEnviados = 0;
    public int paquetesEntregados = 0;
    public int dineroGanado = 0;
    public float incrementoGanancia = 1.05f; // Factor para incrementar ganancia
    private static int contadorMulta = 0;
    private List<Paquete> paquetesDelDia;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
        }
    }

    private void Start()
    {
        IniciarNuevoDia();
    }

    public void ReiniciarPartida()
    {
        currentDay = 0;
        paquetesEnviados = 0;
        paquetesEntregados = 0;
        dineroGanado = 0;
        IniciarNuevoDia();
    }

     public void IniciarNuevoDia()
    {
        currentDay++;
        paquetesEnviados = 0;
        paquetesEntregados = 0;
        dineroGanado = 0;
        paquetesDelDia = new List<Paquete>();
    }


      

    public void EntregarPaquete()
    {
        paquetesEntregados++;
    }

     public void PaqueteDespachado(int costo)
    {
        paquetesEnviados++;
        dineroGanado += Mathf.RoundToInt(costo * incrementoGanancia); // Convierte a int
        UIManager.Instance.MostrarEstadisticas();
    }

  /* public void RecibirPaquetesIntensivo()
    {
        // Generar paquetes adicionales durante la hora pico
        for (int i = 0; i < 5; i++)
        {
            Paquete nuevoPaquete = new Paquete("Destino aleatorio", Random.Range(1f, 10f), Random.Range(10f, 50f));
            paquetesDelDia.Add(nuevoPaquete);
        }
    }*/

    // Método para registrar la multa
    public void RegistrarMulta(int multa, string razon)
    {
        contadorMulta++;    
        dineroGanado -= multa;
        Debug.Log("Multa aplicada: " + multa + " por " + razon);
        NotificacionManager.Instance.MostrarNotificacion($"Multa Aplicada. Monto: {multa}, Razón: {razon}.$");
    }
}
