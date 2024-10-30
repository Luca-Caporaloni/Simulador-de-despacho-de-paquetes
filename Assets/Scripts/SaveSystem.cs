using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string savePath = Application.persistentDataPath + "/simuladorSave.json";

    public static void SaveData(DayManager dayManager)
    {
        SimuladorData data = new SimuladorData(dayManager);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    public static SimuladorData LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<SimuladorData>(json);
        }
        else
        {
            Debug.LogError("Archivo de guardado no encontrado en " + savePath);
            return null;
        }
    }

    public static bool ExistePartidaGuardada()
    {
        return File.Exists(savePath);
    }

    public static void EliminarPartidaGuardada()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Archivo de guardado eliminado en " + savePath);
        }
        else
        {
            Debug.LogWarning("No se encontró un archivo de guardado para eliminar.");
        }
    }
}
