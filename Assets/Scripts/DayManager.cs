using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int currentDay = 1;
    public int paquetesEnviados = 0;
    public int paquetesEntregados = 0;
    public float dineroGanado = 0f;
    private List<Paquete> paquetesDelDia;

    private void Start()
    {
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

    public void DespacharPaquete(Paquete paquete)
    {
        paquetesEnviados++;
        dineroGanado += paquete.valor;
        paquetesDelDia.Add(paquete);
    }

    public void EntregarPaquete()
    {
        paquetesEntregados++;
    }
}
