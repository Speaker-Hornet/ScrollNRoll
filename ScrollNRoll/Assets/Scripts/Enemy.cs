using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    public float health = 100f;

    public Material material;
    public Texture2D texture;

    private bool dead;

    public bool groupious;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " took " + amount + " damage. Remaining: " + health);
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Update()
    {
        Transform oldpos = this.transform;
        if (dead)
        {

            transform.position = new Vector3(oldpos.position.x, oldpos.position.y - 0.05f, oldpos.position.z);
        }
    }

    void Die()
    {
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