using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private float fadeDuration = 3.0f;
    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGrounp(canvasGroup,canvasGroup.alpha,0,fadeDuration));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGrounp(canvasGroup, canvasGroup.alpha, 1, fadeDuration));
    }

    private IEnumerator FadeCanvasGrounp(CanvasGroup cg,float start,float end,float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            cg.alpha=Mathf.Lerp(start,end,elapsedTime/duration);
            yield return null;
        }
        cg.alpha = end;
    }
}
