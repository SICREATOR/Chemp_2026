using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsController : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle musicToggle;

    private string[] supportedResolutions = { "1920x1080", "1280x720", "800x600" };

    private void Start()
    {
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(new System.Collections.Generic.List<string>(supportedResolutions));

        GameSettings settings = SettingsManager.Instance.currentSettings;

        int resIndex = System.Array.IndexOf(supportedResolutions, settings.resolution);
        resolutionDropdown.value = resIndex >= 0 ? resIndex : 0;

        musicToggle.isOn = settings.musicEnabled;

        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        musicToggle.onValueChanged.AddListener(OnMusicToggled);

    }

    void OnResolutionChanged(int index)
    {
        SettingsManager.Instance.currentSettings.resolution = supportedResolutions[index];
        SettingsManager.Instance.SaveSettings();
    }

    void OnMusicToggled(bool isOn)
    {
        SettingsManager.Instance.currentSettings.musicEnabled = isOn;
        SettingsManager.Instance.SaveSettings();
    }
}
