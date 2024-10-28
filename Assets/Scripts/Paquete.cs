using UnityEngine;

[System.Serializable]
public class Paquete
{
    public string destino;
    public float peso;
    public float valor;

    public Paquete(string destino, float peso, float valor)
    {
        this.destino = destino;
        this.peso = peso;
        this.valor = valor;
    }
}
