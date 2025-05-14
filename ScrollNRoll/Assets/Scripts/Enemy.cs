using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [NonSerialized]public float health;

    public Material material;
    public Texture2D texture;

    private bool dead;

    public bool groupious;
    BoxCollider bc;

    EnemyFlash ef;


    private void Awake()
    {
        health = GameManager.Instance.stats.HitsRequiredToKill;
        if (GetComponent<BoxCollider>()) bc = GetComponent<BoxCollider>();
        if (GetComponent<EnemyFlash>()) ef = GetComponent<EnemyFlash>();
    }


    public void TakeDamage(float amount)
    {
        SoundManager.Instance.PlayHitSound();
        health -= amount;
        if (ef) ef.TakeDamage();
        if (health <= 0f)
        {
            if (bc) bc.enabled = false;
            Die();
        }

    }

    private void Update()
    {
        Transform oldpos = this.transform;
        if (dead)
        {

            transform.position = new Vector3(oldpos.position.x, oldpos.position.y - 0.1f, oldpos.position.z);
        }
    }

    void Die()
    {
        SoundManager.Instance.PlayDieSound();
        GameManager.Instance.dopamineCurrent += GameManager.Instance.stats.DopamineAddedOnKill;
        if (groupious) Destroy(this.gameObject);
        //material.mainTexture = texture;
        dead = true;
        StartCoroutine(WaitThenDoSomething());
    }

    IEnumerator WaitThenDoSomething()
    {
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
        
    }
}