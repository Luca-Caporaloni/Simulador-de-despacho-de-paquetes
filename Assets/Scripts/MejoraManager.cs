using UnityEngine;
using UnityEngine.UI;

public class MejoraManager : MonoBehaviour
{
    public static MejoraManager Instance;
    public GameObject panelMejoras; // Asignar el panel de mejoras en el Inspector

    public int costoMejoraAlmacen = 2000;
    public int incrementoEspacioAlmacen = 2;
    public int costoMejoraGanancia = 2000;
    public float incrementoGanancia = 1.05f;

    public Button botonMejoraAlmacen;
    public Button botonMejoraGanancia;

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
        botonMejoraAlmacen.onClick.AddListener(MejorarAlmacen);
        botonMejoraGanancia.onClick.AddListener(MejorarGanancia);
    }

  public void MejorarAlmacen()
{
    if (DayManager.Instance.dineroGanado >= costoMejoraAlmacen)
    {
        DayManager.Instance.dineroGanado -= costoMejoraAlmacen;
        AlmacenManager.Instance.espacioMaximo += incrementoEspacioAlmacen;
        costoMejoraAlmacen = Mathf.RoundToInt(costoMejoraAlmacen * 1.2f); // Incrementa el costo un 20%
        
        Debug.Log("Mejora de almacén realizada.");
        NotificacionManager.Instance.MostrarNotificacion($"Espacio incrementado a {AlmacenManager.Instance.espacioMaximo}. Nuevo costo: {costoMejoraAlmacen}$");
    }
    else
    {
        NotificacionManager.Instance.MostrarNotificacion("Dinero insuficiente para mejorar el almacén.");
    }
}



    public void MejorarGanancia()
{
    if (DayManager.Instance.dineroGanado >= costoMejoraGanancia)
    {
        DayManager.Instance.dineroGanado -= costoMejoraGanancia;
        DayManager.Instance.incrementoGanancia *= incrementoGanancia;

        Debug.Log("Mejora de ganancia realizada.");
        NotificacionManager.Instance.MostrarNotificacion($"Mejora realizada: Ganancia incrementada en un {Mathf.Round((incrementoGanancia - 1f) * 100f)}%");
    }
    else
    {
        Debug.Log("No tienes suficiente dinero para mejorar la ganancia.");
        NotificacionManager.Instance.MostrarNotificacion("No tienes suficiente dinero para mejorar la ganancia.");
    }
}

public void AlternarPanelMejoras()
{
    if (panelMejoras != null)
    {
        bool estadoActual = panelMejoras.activeSelf;
        panelMejoras.SetActive(!estadoActual);
    }
}


    public void AbrirPanelMejoras()
    {
        if (panelMejoras != null)
        {
            panelMejoras.SetActive(true);
        }
    }

    public void CerrarPanelMejoras()
    {
        if (panelMejoras != null)
        {
            panelMejoras.SetActive(false);
        }
    }
}
