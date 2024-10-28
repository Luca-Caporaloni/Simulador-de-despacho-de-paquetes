using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public DayManager dayManager;
    public UIManager uiManager;
    public Button saveButton;
    public Button loadButton;

    private void Start()
    {
        saveButton.onClick.AddListener(GuardarProgreso);
        loadButton.onClick.AddListener(CargarProgreso);
    }

    private void GuardarProgreso()
    {
        SaveSystem.SaveData(dayManager);
    }

    private void CargarProgreso()
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
