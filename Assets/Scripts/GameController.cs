using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } // Singleton Instance

    public DayManager dayManager;
    public UIManager uiManager;
    public Button saveButton;
    public Button loadButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Permitir que persista entre escenas
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados
        }
    }

    private void Start()
    {
        if (SaveSystem.ExistePartidaGuardada())
    {
        
    }
    
        saveButton.onClick.AddListener(GuardarProgreso);
        loadButton.onClick.AddListener(CargarProgreso);
    }

    public void GuardarProgreso()
    {
        SaveSystem.SaveData(dayManager);
        Debug.Log("Progreso guardado."); // Confirmación visual
    }

    public void CargarProgreso()
    {
        SimuladorData data = SaveSystem.LoadData();
        if (data != null)
        {
            dayManager.currentDay = data.currentDay;
            dayManager.paquetesEnviados = data.paquetesEnviados;
            dayManager.paquetesEntregados = data.paquetesEntregados;
            dayManager.dineroGanado = Mathf.FloorToInt(data.dineroGanado);
            UIManager.Instance.MostrarEstadisticas(); // Actualizar UI
            Debug.Log("Progreso cargado."); // Confirmación visual
        }
        else
        {
            Debug.LogWarning("No se encontró una partida guardada para cargar.");
        }
    }
}
