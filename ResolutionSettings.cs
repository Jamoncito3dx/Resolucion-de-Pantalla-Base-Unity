using UnityEngine;
using TMPro;

public class ResolutionSettings : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Dropdown resolutionDropdown; // Referencia al Dropdown de TMP

    private Resolution[] availableResolutions; // Lista de resoluciones disponibles

    private void Start()
    {
        if (resolutionDropdown != null)
        {
            PopulateResolutionDropdown();
            resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        }
        else
        {
            Debug.LogError("No se asignó el TMP Dropdown en ResolutionSettings.");
        }
    }

    private void PopulateResolutionDropdown()
    {
        // Obtener las resoluciones disponibles
        availableResolutions = Screen.resolutions;

        // Limpiar las opciones actuales del Dropdown
        resolutionDropdown.ClearOptions();

        // Crear una lista para almacenar las opciones
        var options = new System.Collections.Generic.List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < availableResolutions.Length; i++)
        {
            // Calcular la frecuencia en Hz
            int refreshRateHz = Mathf.RoundToInt((float)availableResolutions[i].refreshRateRatio.numerator / availableResolutions[i].refreshRateRatio.denominator);

            // Crear texto para cada resolución sin el "@" antes de la frecuencia
            string option = $"{availableResolutions[i].width} x {availableResolutions[i].height} {refreshRateHz}Hz";
            options.Add(option);

            // Detectar la resolución actual
            if (availableResolutions[i].width == Screen.currentResolution.width &&
                availableResolutions[i].height == Screen.currentResolution.height &&
                availableResolutions[i].refreshRateRatio.Equals(Screen.currentResolution.refreshRateRatio))
            {
                currentResolutionIndex = i;
            }
        }

        // Añadir las opciones al Dropdown y establecer el valor inicial
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void OnResolutionChanged(int selectedIndex)
    {
        // Cambiar la resolución según la selección
        Resolution selectedResolution = availableResolutions[selectedIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreenMode, selectedResolution.refreshRateRatio);
        Debug.Log($"Resolución cambiada a: {selectedResolution.width}x{selectedResolution.height} {Mathf.RoundToInt((float)selectedResolution.refreshRateRatio.numerator / selectedResolution.refreshRateRatio.denominator)}Hz");
    }

    private void OnDestroy()
    {
        // Remover el listener para evitar errores si el objeto es destruido
        if (resolutionDropdown != null)
        {
            resolutionDropdown.onValueChanged.RemoveListener(OnResolutionChanged);
        }
    }
}
