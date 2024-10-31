using UnityEngine;

public class PaqueteInteract : MonoBehaviour
{

    public static PaqueteInteract Instance;

    public string destino;
    public float peso;
    public float valor; // Añade el campo de valor aquí
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


    private void GenerarDetallesAleatorios()
    {
        // Generar un paquete con detalles aleatorios
        string[] destinos = { "Nueva York", "Londres", "París", "Tokio", "Sídney" };
        string destino = destinos[Random.Range(0, destinos.Length)];
        float peso = Random.Range(1f, 20f); // Peso entre 1 y 20 kg
        float valor = peso * 10f; // Valor basado en el peso
        bool esFragil = Random.value > 0.5f; // 50% de probabilidad de ser frágil

        // Crear el paquete usando los parámetros generados
        Paquete paquete = new Paquete(destino, peso, valor);

        // Mostrar detalles en la UI
        uiDetallesPaquete.MostrarDetalles(paquete, esFragil, paquete.horaEntrega);
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
        // Verificar el destino ingresado y aplicar multa si no coincide
        bool destinoCorrecto = destinoIngresado.Equals(destino, System.StringComparison.OrdinalIgnoreCase);
        if (!destinoCorrecto)
        {
            AplicarMulta("Destino incorrecto");
        }

        // Verificar el horario de despacho y aplicar multa si es tardío
        if (!EsHoraCorrecta(horaDespacho))
        {
            AplicarMulta("Entrega tardía");
        }

        // Registrar el despacho si todo es correcto
        int costoPaquete = Mathf.RoundToInt(valor); 
        DayManager.Instance.PaqueteDespachado(costoPaquete);

        Destroy(gameObject); // Destruir el paquete tras el despacho
    }

    private bool EsHoraCorrecta(string horaDespacho)
    {
        // Parsear horas y minutos del string de hora de entrega y de despacho
        string[] entregaSplit = horaEntrega.Split(':');
        string[] despachoSplit = horaDespacho.Split(':');

        int horaEntregaInt = int.Parse(entregaSplit[0]);
        int minutosEntregaInt = int.Parse(entregaSplit[1]);

        int horaDespachoInt = int.Parse(despachoSplit[0]);
        int minutosDespachoInt = int.Parse(despachoSplit[1]);

        // Comparar horas y minutos
        if (horaDespachoInt > horaEntregaInt || 
            (horaDespachoInt == horaEntregaInt && minutosDespachoInt > minutosEntregaInt))
        {
            return false; // La hora de despacho es después de la hora de entrega
        }

        return true; // La hora de despacho es puntual
    }

    private void AplicarMulta(string razon)
    {
        int multa = Mathf.RoundToInt(valor * 0.2f); // Multa del 20% del valor del paquete
        DayManager.Instance.RegistrarMulta(multa, razon);
    }
}
