using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroupiousPosition
{
    public float distance;
    public float x;
    public float y;
    public GroupiousPosition(float newDistance, float newX, float newY)
    {
        distance = newDistance;
        x = newX;
        y = newY;
    }
}

public class Grupius : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The camera to face (defaults to main camera)")]
    [NonSerialized]public Camera targetCamera;

    [Tooltip("Distance from camera")]
    public float distance = 2.0f;

    [Tooltip("Viewport position (0-1) where 0.5,0.5 is center")]
    public Vector2 viewportPosition = new Vector2(0.5f, 0.5f);

    [Tooltip("Should the object rotate to always face the camera?")]
    public bool faceCamera = true;

    [Tooltip("Should the object maintain its relative size regardless of distance?")]
    public bool maintainSize = true;

    [Tooltip("Base size of the object when maintainSize is true")]
    public float baseSize = 1.0f;

    [Header("Timer Settings")]
    public float firstState;
    public float secondState;
    public float thirdState;
    public float reset;

    public Texture2D state0;
    public Texture2D state1;
    public Texture2D state2;
    public Texture2D state3;

    public Material material;

    private float currentTime;

     [Header("Oscillation Settings")]
    [Tooltip("How far the object moves up and down")]
    [SerializeField] float amplitude = 0.5f;
    
    [Tooltip("How fast the object oscillates")]
    [SerializeField] float frequency = 1.0f;

    private void Start()
    {
        currentTime = 0f;

        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }

        GroupiousPosition g1 = new GroupiousPosition(2f, 0.5f, 0.5f);
        GroupiousPosition g2 = new GroupiousPosition(3f, 0.2f, 0.5f);
        GroupiousPosition g3 = new GroupiousPosition(3f, 0.85f, 0.59f);
        GroupiousPosition g4 = new GroupiousPosition(2.4f, 0.7f, 0.75f);
        GroupiousPosition g5 = new GroupiousPosition(2.4f, 0.35f, 0.8f);
        GroupiousPosition g6 = new GroupiousPosition(3f, 0.4f, 0.7f);
        GroupiousPosition g7 = new GroupiousPosition(2f, 0.7f, 0.6f);
        GroupiousPosition g8 = new GroupiousPosition(2.1f, 0.6f, 0.7f);
        GroupiousPosition g9 = new GroupiousPosition(2.2f, 0.5f, 0.83f);

        List<GroupiousPosition> gs = new List<GroupiousPosition>();

        gs.Add(g1);
        gs.Add(g2);
        gs.Add(g3);
        gs.Add(g4);
        gs.Add(g5);
        gs.Add(g6);
        gs.Add(g7);
        gs.Add(g8);
        gs.Add(g9);

        int r = UnityEngine.Random.Range(0, 9);

        distance = gs[r].distance;
        viewportPosition = new Vector2(gs[r].x, gs[r].y);

        StartCoroutine(WaitThenDoSomething());
    }

    private void Update()
    {
        //currentTime += Time.deltaTime;

        //Debug.Log(currentTime + this.name);

        //if (currentTime >= reset)
        //{
        //    material.mainTexture = state0;
        //    currentTime = 0f;
        //}
        //else if (currentTime >= thirdState)
        //{
        //    material.mainTexture = state3;
        //    //pucaj
        //}
        //else if (currentTime >= secondState)
        //{
        //    material.mainTexture = state2;
        //}
        //else if (currentTime >= firstState)
        //{
        //    material.mainTexture = state1;
        //}

        if (targetCamera == null)
            return;

        // Calculate the position in viewport space
        Vector3 viewportPoint = new Vector3(viewportPosition.x, viewportPosition.y, distance);

        // Convert viewport position to world position
        Vector3 worldPosition = targetCamera.ViewportToWorldPoint(viewportPoint);

        // Set the object's position
        transform.position = worldPosition;
        float newY = transform.position.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Face the camera if enabled
        if (faceCamera)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - targetCamera.transform.position);
        }

        // Maintain size if enabled
        if (maintainSize)
        {
            float currentDistance = Vector3.Distance(transform.position, targetCamera.transform.position);
            float scale = currentDistance * baseSize / distance;
            transform.localScale = Vector3.one * scale;
        }
    }

    IEnumerator WaitThenDoSomething()
    {
        yield return new WaitForSeconds(firstState);
        material.mainTexture = state1;
        yield return new WaitForSeconds(secondState);
        material.mainTexture = state2;
        yield return new WaitForSeconds(thirdState);
        material.mainTexture = state3;
        GameManager.Instance.dopamineCurrent -= GameManager.Instance.stats.FlyingEnemyDmg;
        yield return new WaitForSeconds(reset);
        material.mainTexture = state0;

        StartCoroutine(WaitThenDoSomething());
    }
}
