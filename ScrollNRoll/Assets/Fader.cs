using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeDuration = 1f;

    private void Start()
    {
        // Optional: start with fade in
        StartCoroutine(FadeFromBlack());
    }

    public void FadeToBlackAndBack()
    {
        StartCoroutine(FadeToBlackAndBackRoutine());
    }

    private IEnumerator FadeToBlackAndBackRoutine()
    {
        yield return StartCoroutine(FadeToBlack());
        yield return new WaitForSeconds(1f); // stay black for a moment
        yield return StartCoroutine(FadeFromBlack());
    }

    public IEnumerator FadeToBlack()
    {
        fadeImage.gameObject.SetActive(true);
        yield return Fade(0f, 1f);
    }

    public IEnumerator FadeFromBlack()
    {
        yield return Fade(1f, 0f);
        fadeImage.gameObject.SetActive(false);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure final alpha
        fadeImage.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
