using UnityEngine;
using System.Collections;

public class EnemyFlash : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material material;
    public float flashDuration = 0.1f;
    private Coroutine flashRoutine;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material; // creates a unique instance
    }

    public void TakeDamage()
    {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);
        
        flashRoutine = StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        material.SetFloat("_FlashAmount", 1f);
        yield return new WaitForSeconds(flashDuration);
        material.SetFloat("_FlashAmount", 0f);
    }
}
