using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;

public class LocalizationManager : MonoBehaviour
{
    public TextMeshProUGUI frenchText;
    public TextMeshProUGUI englishText;
    
    public void SetFrench()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        frenchText.fontStyle = FontStyles.Bold;
        englishText.fontStyle = FontStyles.Normal;
    }


    public void SetEnglish()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        frenchText.fontStyle = FontStyles.Normal;
        englishText.fontStyle = FontStyles.Bold;
    }
}
