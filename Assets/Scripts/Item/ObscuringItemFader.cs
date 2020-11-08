using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObscuringItemFader : MonoBehaviour
{
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private SpriteRenderer renderer;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }

    private IEnumerator FadeInRoutine()
    {
        float currentAlpha = renderer.color.a;
        float distance = 1f - currentAlpha;

        while (1f - currentAlpha < 0.01f)
        {
            currentAlpha = currentAlpha + distance / Settings.fadeInSeconds * Time.deltaTime;
            renderer.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }

        renderer.color = new Color(1f, 1f, 1f, 1f);
    }

    private IEnumerator FadeOutRoutine()
    {
        float currentAlpha = renderer.color.a;
        float distance = currentAlpha - Settings.targetAlpha; ;

        while (currentAlpha - Settings.targetAlpha > 0.01f)
        {
            currentAlpha = currentAlpha - distance / Settings.fadeOutSeconds * Time.deltaTime;
            renderer.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }

        renderer.color = new Color(1f, 1f, 1f, Settings.targetAlpha);
    }
}