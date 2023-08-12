using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DiaryView
{

    [SerializeField] CanvasGroup UICharacter;
    [SerializeField] CanvasGroup UISettings;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text descriptionText;

    public void UpdateDiaryView(CharacterData data)
    {
        CloseOptions();
        icon.sprite = data.PortraitBig;
        nameText.text = data.Name;
        descriptionText.text = data.Description;     
    }

    public void OpenOptions()
    {
        UICharacter.gameObject.SetActive(false);
        UISettings.gameObject.SetActive(true);
    }

    public void CloseOptions() 
    {
        UICharacter.gameObject.SetActive(true);
        UISettings.gameObject.SetActive(false);
    }


}
