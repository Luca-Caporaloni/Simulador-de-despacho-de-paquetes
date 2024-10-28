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
            dayManager.dineroGanado = data.dineroGanado;
            uiManager.MostrarEstadisticas();
        }
    }
}
