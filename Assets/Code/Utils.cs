using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Utils
{
    public static IEnumerator FadeAlpha(CanvasGroup canvasGroup, float from, float to, float fadeTime, System.Action postCall = null)
    {
        canvasGroup.alpha = from;

        var timeElapsed = 0f;

        while (timeElapsed < fadeTime)
        {
            var fraction = timeElapsed / fadeTime;
            timeElapsed += Time.deltaTime;

            float a = Mathf.Lerp(from, to, fraction);

            canvasGroup.alpha = a;
            yield return null;
        }

        canvasGroup.alpha = to;
        if (to == 0)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        postCall?.Invoke();
    }

    public static void GameExit()
    {
        Debug.Log("Game exit");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
