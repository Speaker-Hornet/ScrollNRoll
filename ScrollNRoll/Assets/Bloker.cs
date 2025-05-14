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

    MeshRenderer meshRenderer;
    Material mat;

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


        meshRenderer = GetComponent<MeshRenderer>();
        mat = meshRenderer.material;
    }

    public void Start()
    {

        StartCoroutine(WaitThenDoSomething());
    }

    IEnumerator WaitThenDoSomething()
    {
        yield return new WaitForSeconds(1f);
        
        /*if(material.mainTexture == slika1)*/ if (mat.GetTexture("_Texture2D")==slika1)
        {
            //material.mainTexture = slika2;
            mat.SetTexture("_Texture2D",slika2);
        }
        else
        {
            //material.mainTexture = slika1;
            mat.SetTexture("_Texture2D",slika1);
        }
            StartCoroutine(WaitThenDoSomething());
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;

        GetComponent<BoxCollider>().enabled= false;

        GameManager.Instance.dopamineCurrent -= GameManager.Instance.dopamineToDeplete;

        ArcadeCarController.Instance.rb.linearVelocity /= 4f;

        GetComponent<AudioSource>().Play();

        GameManager.Instance.dopamineCurrent -= GameManager.Instance.stats.StandingEnemyDmg;
        SceneManager.Instance.EnableHurtUI();
        

        Destroy(this);
    }
    
}
