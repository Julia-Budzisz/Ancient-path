using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Controls death effect

public class DeathFade : MonoBehaviour
{
    // Image used for fade effect
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        // Fade to transparent
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;
    }

    // Starts fade out and in effect
    public void FadeOutAndIn(System.Action onFadeComplete = null)
    {
        StartCoroutine(FadeCoroutine(onFadeComplete));
    }

    private IEnumerator FadeCoroutine(System.Action onFadeComplete)
    {
        // Fade to black
        float timer = 0f;
        Color color = fadeImage.color;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        color.a = 1f;
        fadeImage.color = color;

        // Invoke callback after fade out
        onFadeComplete?.Invoke();

        // Fade back
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        color.a = 0f;
        fadeImage.color = color;
    }
}

