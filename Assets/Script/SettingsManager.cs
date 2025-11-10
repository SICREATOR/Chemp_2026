using System;
using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    private string settingsPath;

    public GameSettings currentSettings;

    private void Awake()
    {
        Instance = this;
        settingsPath = Path.Combine(Application.persistentDataPath, "settings.json");  
        LoadSettings();
    }

    public void SaveSettings()
    {
        string json = JsonUtility.ToJson(currentSettings, true);
        File.WriteAllText(settingsPath, json);
        Debug.Log($"Настройки сохранены: {json}");
    }

    public void LoadSettings()
    {
        if (File.Exists(settingsPath))
        {
            string json = File.ReadAllText(settingsPath);
            currentSettings = JsonUtility.FromJson<GameSettings>(json);
            Debug.Log($"Загружены настройки из JSON: разрешение = {currentSettings.resolution}, музыка = {(currentSettings.musicEnabled ? "вкл" : "выкл")}");
        }
        else
        {
            currentSettings = new GameSettings();
            Debug.Log("Файл настроек не найден. Используются значения по умолчанию.");
        }
    }
}

[Serializable]
public class GameSettings
{
    public string resolution;
    public bool musicEnabled;
}
