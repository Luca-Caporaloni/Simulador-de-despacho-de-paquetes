[System.Serializable]
public class SimuladorData
{
    public int currentDay;
    public int paquetesEnviados;
    public int paquetesEntregados;
    public float dineroGanado;

    public SimuladorData(DayManager dayManager)
    {
        currentDay = dayManager.currentDay;
        paquetesEnviados = dayManager.paquetesEnviados;
        paquetesEntregados = dayManager.paquetesEntregados;
        dineroGanado = dayManager.dineroGanado;
    }
}
