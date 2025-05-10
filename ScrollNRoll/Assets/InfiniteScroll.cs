using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    [Header("References")]
    public ScrollRect scrollRect;
    public RectTransform contentRect;
    public VerticalLayoutGroup contentLayoutGroup;
    public GameObject reklama; // 5% chance
    public GameObject rils; // 95% chance

    public int chanceForAdd;

    public List<GameObject> items;

    private Vector2 startingPos;

    Vector2 oldVelocity;
    bool isUpdated;

    private void Awake()
    {
        isUpdated = false;
        oldVelocity = Vector2.zero;

        startingPos = contentRect.anchoredPosition;

        for (int i = 0; i < 150; i++)
        {
            int r = Random.Range(0, 100);

            if (r <= chanceForAdd)
            {
                GameObject newRils = Instantiate(reklama, contentRect);
                items.Add(newRils);
            }
            else
            {
                GameObject newRils = Instantiate(rils, contentRect);
                items.Add(newRils);
            }
        }
    }

    private void FixedUpdate()
    {
        oldVelocity = scrollRect.velocity;

        if (Mathf.Abs(startingPos.y - contentRect.anchoredPosition.y) > 37500)
        {
            Refresh();
            Spawn();
        }

        scrollRect.velocity = oldVelocity;
    }

    public void Spawn()
    {
        for (int i = 0; i < 10; i++)
        {
            Destroy(items[0]);
            items.RemoveAt(0);
            int r = Random.Range(0, 100);
            Debug.Log("RANDOM " + r);

            if (r <= 5)
            {
                Debug.Log("ril");
                GameObject newRils = Instantiate(rils, contentRect);
                items.Add(newRils);
            }
            else
            {
                Debug.Log("reklama");
                GameObject newRils = Instantiate(reklama, contentRect);
                items.Add(newRils);
            }
        }
    }

    public void Refresh()
    {
        

        contentRect.anchoredPosition = startingPos;

        
    }
}