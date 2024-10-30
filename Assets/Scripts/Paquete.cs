using UnityEngine;

[System.Serializable]
public class Paquete
{
    public string destino;
    public float peso;
    public float valor;
    public bool esFragil;
    public string horaEntrega;

    // Constructor
    public Paquete(string destino, float peso, float valor)
    {
        this.destino = destino;
        this.peso = peso;
        this.valor = valor; // Asegúrate de asignar el valor
        this.esFragil = Random.value > 0.5f; // Asignación aleatoria de fragilidad
        this.horaEntrega = GenerarHoraEntrega(); // Generar hora de entrega aleatoria
    }

    private float CalcularValor(float peso)
    {
        return peso * Random.Range(10, 20); // Calcula el valor
    }

    private string GenerarHoraEntrega()
    {
        int hora = Random.Range(8, 20);
        int minutos = Random.Range(0, 60);
        return hora.ToString("00") + ":" + minutos.ToString("00");
    }
}

