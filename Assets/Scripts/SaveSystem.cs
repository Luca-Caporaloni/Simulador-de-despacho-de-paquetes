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
}
