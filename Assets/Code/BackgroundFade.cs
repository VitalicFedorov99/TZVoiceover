using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFade : MonoBehaviour
{

    [SerializeField] CanvasGroup group;
    [SerializeField] float fadeTime;

    bool isShow;
    public void Fade()
    {
        if (isShow)
        {
            StartCoroutine(Utils.FadeAlpha(group, 1, 0, fadeTime));
            isShow = false;
        }
    }
    public void Show()
    {
        if (!isShow)
        {
            StartCoroutine(Utils.FadeAlpha(group, 0, 1, fadeTime));
            isShow = true;
        }
    }
}
