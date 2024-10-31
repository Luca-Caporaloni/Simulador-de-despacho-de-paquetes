using UnityEngine;

[System.Serializable]
public class Paquete
{
    public string destino;
    public float peso;
    public float valor;
    public bool esFragil;
    public string horaEntrega;

    // Constructor que asigna valores aleatorios
    public Paquete(string destino, float peso, float valor)
    {
        this.destino = destino;
        this.peso = peso;
        this.valor = valor;
        this.esFragil = Random.value > 0.5f; // 50% de probabilidad de ser frágil
        this.horaEntrega = GenerarHoraEntrega(); // Generar hora de entrega aleatoria
    }

    private string GenerarHoraEntrega()
    {
        int hora = Random.Range(8, 20); // Horas entre 8 y 19
        int minutos = Random.Range(0, 60); // Minutos entre 0 y 59
        return hora.ToString("00") + ":" + minutos.ToString("00"); // Formato "HH:mm"
    }
}
