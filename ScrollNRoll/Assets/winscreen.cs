using UnityEngine;
using UnityEngine.UI;

public class winscreen : MonoBehaviour
{
    public RectTransform transitionImage;
    public float duration = 1.5f;
    public AnimationCurve scaleCurve;
    public AnimationCurve rotationCurve;

    private Vector3 initialScale;
    private Quaternion initialRotation;

    void Start()
    {
        initialScale = Vector3.zero;
        initialRotation = Quaternion.identity;

        transitionImage.localScale = initialScale;
        transitionImage.localRotation = initialRotation;

        StartCoroutine(PlayTransition());
    }

    System.Collections.IEnumerator PlayTransition()
    {
        float timer = 0f;

        while (timer < duration)
        {
            float t = timer / duration;

            float scale = scaleCurve.Evaluate(t);
            float rotation = rotationCurve.Evaluate(t);

            transitionImage.localScale = Vector3.one * scale;
            transitionImage.localRotation = Quaternion.Euler(0f, 0f, rotation);

            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure final state
        transitionImage.localScale = Vector3.one;
        transitionImage.localRotation = Quaternion.identity;
    }
}
