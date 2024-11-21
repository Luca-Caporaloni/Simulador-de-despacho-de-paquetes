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
            Debug.Log("Mejora de almacén realizada. Espacio actual: " + AlmacenManager.Instance.espacioMaximo);
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para mejorar el almacén.");
        }
    }

    public void MejorarGanancia()
    {
        if (DayManager.Instance.dineroGanado >= costoMejoraGanancia)
        {
            DayManager.Instance.dineroGanado -= costoMejoraGanancia;
            DayManager.Instance.incrementoGanancia *= incrementoGanancia;
            Debug.Log("Mejora de ganancia realizada.");
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para mejorar la ganancia.");
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
