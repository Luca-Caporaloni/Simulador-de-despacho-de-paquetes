using UnityEngine;

public class PaqueteInteract : MonoBehaviour
{

    public static PaqueteInteract Instance;

    public string destino;
    public float peso;
    public float valor;
    public bool esFragil;
    public string horaEntrega;
    

    public UIDetallesPaquete uiDetallesPaquete;





    private void Start()
{
    if (uiDetallesPaquete == null)
    {
        
        uiDetallesPaquete = UIDetallesPaquete.Instance;
        if (uiDetallesPaquete == null)
        {
            Debug.LogError("No se encontró UIDetallesPaquete en la escena. Verifica que el objeto esté presente.");
        }
        else
        {
            GenerarDetallesAleatorios(); // Generar detalles aleatorios solo si la instancia existe
        }
    }
}


    public void GenerarDetallesAleatorios()
{
    string[] destinos = { "Nueva York", "Londres", "París", "Tokio", "Sídney" };
    destino = destinos[Random.Range(0, destinos.Length)];
    peso = Random.Range(1f, 20f);
    valor = peso * 10f;
    esFragil = Random.value > 0.5f;
    horaEntrega = Paquete.GenerarHoraEntrega();

    Paquete paquete = new Paquete(destino, peso, valor);

    Debug.Log($"Generando paquete: Destino={paquete.destino}, Peso={paquete.peso}, Valor={paquete.valor}, Hora={horaEntrega}");

    if (uiDetallesPaquete != null)
    {
        //uiDetallesPaquete.MostrarDetalles(paquete, esFragil, horaEntrega);
    }
    else
    {
        Debug.LogError("uiDetallesPaquete no está asignado o es nulo.");
    }
}




    public void InspeccionarPaquete()
{
    if (uiDetallesPaquete != null)
    {
        // Asegúrate de que 'peso' y 'valor' estén correctamente calculados o asignados
        peso = Random.Range(1f, 20f); // Si no has asignado peso en otro lugar
        float valor = peso * 10f; // Calcular el valor basado en el peso

        // Crear el paquete usando los tres parámetros necesarios
        Paquete paquete = new Paquete(destino, peso, valor);
        uiDetallesPaquete.MostrarDetalles(paquete, esFragil, horaEntrega);
    }
}


   public void DespacharPaquete(string destinoIngresado, string horaDespacho)
{
    string destinoNormalizado = NormalizarTexto(destino);
    string destinoIngresadoNormalizado = NormalizarTexto(destinoIngresado);

    if (!destinoNormalizado.Equals(destinoIngresadoNormalizado))
    {
        AplicarMulta("Destino incorrecto");
        Debug.LogError($"Multa aplicada. Destino esperado: {destinoNormalizado}, ingresado: {destinoIngresadoNormalizado}");
        return;
    }

    if (!EsHoraCorrecta(horaDespacho))
    {
        AplicarMulta("Entrega tardía");
        Debug.LogError($"Multa por entrega tardía. Hora esperada: {horaEntrega}, ingresada: {horaDespacho}");
        return;
    }

    Debug.Log($"Paquete despachado correctamente a: {destino}");
    int costoPaquete = Mathf.RoundToInt(valor);
    DayManager.Instance.PaqueteDespachado(costoPaquete);

    // Destruir el paquete actual y actualizar la interfaz con el siguiente paquete
    Destroy(gameObject);
    AlmacenManager.Instance.ObtenerPaqueteParaInspeccion();
}




private string NormalizarTexto(string texto)
{
    if (string.IsNullOrEmpty(texto)) return ""; // Evitar errores con cadenas vacías
    return texto.Trim().ToLower().Replace("\n", "").Replace("\r", "");
}



    private bool EsHoraCorrecta(string horaDespacho)
{
    if (string.IsNullOrEmpty(horaEntrega) || string.IsNullOrEmpty(horaDespacho))
    {
        Debug.LogWarning("Hora de entrega o despacho no válidas.");
        return false;
    }

    // Parsear horas y minutos del string de hora de entrega y despacho
    string[] entregaSplit = horaEntrega.Split(':');
    string[] despachoSplit = horaDespacho.Split(':');

    if (entregaSplit.Length != 2 || despachoSplit.Length != 2)
    {
        Debug.LogWarning("Formato de hora inválido.");
        return false;
    }

    int horaEntregaInt = int.Parse(entregaSplit[0]);
    int minutosEntregaInt = int.Parse(entregaSplit[1]);

    int horaDespachoInt = int.Parse(despachoSplit[0]);
    int minutosDespachoInt = int.Parse(despachoSplit[1]);

    // Comparar horas y minutos
    if (horaDespachoInt > horaEntregaInt || 
        (horaDespachoInt == horaEntregaInt && minutosDespachoInt > minutosEntregaInt))
    {
        Debug.LogWarning($"Entrega fuera de horario: Entrega='{horaEntrega}', Despacho='{horaDespacho}'");
        return false;
    }

    return true; // La hora de despacho es puntual
}

private void AplicarMulta(string razon)
{
    int multa = Mathf.RoundToInt(valor * 0.2f); // Ejemplo: multa del 20% del valor del paquete
    DayManager.Instance.RegistrarMulta(multa, razon);
    Debug.Log($"Multa aplicada: {multa}. Razón: {razon}");
}

}
