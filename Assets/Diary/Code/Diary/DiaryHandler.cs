using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryHandler : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeTime = 0.1f;
    [SerializeField] CharacterDataContainer dataContainer;
    [SerializeField] DiaryView diaryView;

    [Header("Events")]
    [SerializeField] GameEvent diaryOpenedEvent;
    [SerializeField] GameEvent diaryClosedEvent;
    [SerializeField] GameEvent diaryPageChanged;

    bool isOpen;
    TypePage pageType = TypePage.Nun;
    public void Close() // OnDiaryClose
    {
        if (!isOpen)
            return;

        isOpen = false;
        pageType = TypePage.Nun;
        dataContainer.SetValue(null);
        diaryClosedEvent.Raise();
        StartCoroutine(Utils.FadeAlpha(canvasGroup, 1, 0, fadeTime));
    }

    public void OpenCharacter() // OnDiaryOpenCharacter
    {
        if (!isOpen)
        {
            diaryOpenedEvent.Raise();
            StartCoroutine(Utils.FadeAlpha(canvasGroup, 0, 1, fadeTime));
            isOpen = true;
            diaryPageChanged.Raise();
        }
        else if (dataContainer.isChangeValue)
        diaryPageChanged.Raise();

        pageType = TypePage.Character;
        diaryView.UpdateDiaryView(dataContainer.Value);

    }

    public void OpenOptions() // OnDiaryOpenOptions
    {
        if (!isOpen)
        {
            diaryOpenedEvent.Raise();
            StartCoroutine(Utils.FadeAlpha(canvasGroup, 0, 1, fadeTime));
            isOpen = true;
            diaryPageChanged.Raise();
        }
        else if(pageType!=TypePage.Options)
        diaryPageChanged.Raise();

        dataContainer.SetValue(null);
        pageType = TypePage.Options;
        diaryView.OpenOptions();
    }

    public void Exit()
    {
        Utils.GameExit();
    }
}


public enum TypePage 
{
    Character,
    Options,
    Nun
}