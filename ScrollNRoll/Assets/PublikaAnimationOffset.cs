using System.Collections;
using UnityEngine;

public class PublikaAnimationOffset : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(OffsetCoroutine());
    }

    IEnumerator OffsetCoroutine()
    {
        float randomOffset = Random.Range(0f, 2f);
        float randomSpeed = Random.Range(0.8f, 1.2f);
        yield return new WaitForSeconds(randomOffset);
        GetComponent<Animator>().Play("Publika");
        GetComponent<Animator>().SetFloat("speed", randomSpeed);
    }
}
