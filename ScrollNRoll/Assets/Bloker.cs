using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Bloker : MonoBehaviour
{
    public Material material;
    public Texture2D slika1;
    public Texture2D slika2;

    private void Awake()
    {
        int r = UnityEngine.Random.Range(1, 3);

        if(r == 1)
        {
            material.mainTexture = slika1;
        }
        else
        {
            material.mainTexture = slika2;
        }
    }

    public void Start()
    {
        StartCoroutine(WaitThenDoSomething());
    }

    IEnumerator WaitThenDoSomething()
    {
        yield return new WaitForSeconds(1f);
        
        if(material.mainTexture == slika1)
        {
            material.mainTexture = slika2;
        }
        else
        {
            material.mainTexture = slika1;
        }
            StartCoroutine(WaitThenDoSomething());
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;

        GameManager.Instance.dopamineCurrent -= GameManager.Instance.dopamineToDeplete;

        ArcadeCarController.Instance.rb.linearVelocity /= 4f;

        GameManager.Instance.dopamineCurrent -= 10f;

        Destroy(this);
    }
}
