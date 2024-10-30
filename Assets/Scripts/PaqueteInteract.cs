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


    private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // Mantener el objeto entre escenas
    }
    else
    {
        Destroy(gameObject); // Si ya existe, destruir este objeto
    }
}


    private void Start()
    {
         if (uiDetallesPaquete == null)
        {
            uiDetallesPaquete = FindObjectOfType<UIDetallesPaquete>();
            GenerarDetallesAleatorios(); // Generar detalles aleatorios al inicio
        }

        
    }

    private void GenerarDetallesAleatorios()
    {
        // Generar peso aleatorio entre 1 y 20 kg
        peso = Random.Range(1f, 20f);

        // Calcular valor en función del peso (por ejemplo, $10 por kg)
        valor = peso * 10f;

        // Definir fragilidad al azar (50% de probabilidad de que sea frágil)
        esFragil = Random.value > 0.5f;

        // Generar un destino aleatorio (por ejemplo, una lista de ciudades)
        string[] destinos = { "Nueva York", "Londres", "París", "Tokio", "Sídney" };
        destino = destinos[Random.Range(0, destinos.Length)];

        // Generar una hora de entrega aleatoria
        int hora = Random.Range(8, 18); // Horario entre las 8 AM y 6 PM
        int minutos = Random.Range(0, 60); // Minutos aleatorios
        horaEntrega = hora.ToString("00") + ":" + minutos.ToString("00");
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
