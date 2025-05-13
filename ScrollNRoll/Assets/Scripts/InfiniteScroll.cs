using System;
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

    [NonSerialized]public int chanceForAdd;

    public List<GameObject> items;

    private Vector2 startingPos;

    Vector2 oldVelocity;
    bool isUpdated;

    public Sprite meme1;
    public Sprite meme2;
    public Sprite meme3;
    public Sprite meme4;

    private int scrollTracker = 0;
    public ParticleSystem scrollClickClick;

    private void Awake()
    {
        isUpdated = false;
        oldVelocity = Vector2.zero;
        chanceForAdd = GameManager.Instance.stats.PercentChanceForAdToAppear;
        startingPos = contentRect.anchoredPosition;

        for (int i = 0; i < 150; i++)
        {
            int r = UnityEngine.Random.Range(0, 100);

            if (r <= chanceForAdd)
            {
                GameObject newRils = Instantiate(reklama, contentRect);
                items.Add(newRils);
            }
            else
            {
                GameObject newRils = Instantiate(rils, contentRect);
                items.Add(newRils);


                int x = UnityEngine.Random.Range(1, 5);
                switch (x)
                {
                    case 1:
                        {
                            newRils.GetComponent<Image>().sprite = meme1;
                        }
                        break;
                    case 2:
                        {
                            newRils.GetComponent<Image>().sprite = meme2;
                        }
                        break;
                    case 3:
                        {
                            newRils.GetComponent<Image>().sprite = meme3;
                        }
                        break;
                    case 4:
                        {
                            newRils.GetComponent<Image>().sprite = meme4;
                        }
                        break;
                    default:
                        {
                            Debug.LogError("????? SPRAJT MEME NE VALJA");
                        }
                        break;
                }
            }
        }
    }

    private void Update()
    {
        scrollReached();
    }

    private void FixedUpdate()
    {
        oldVelocity = scrollRect.velocity;

        //Debug.Log(Mathf.Abs(startingPos.y - contentRect.anchoredPosition.y));
        if (Mathf.Abs(startingPos.y - contentRect.anchoredPosition.y) > 5000)
        {
            Refresh();
            Spawn();
        }

        scrollRect.velocity = oldVelocity;
    }

    public void Spawn()
    {
        // First, clear old items
        foreach (var item in items)
        {
            Destroy(item); // Just destroy the item directly (no need for .gameObject)
        }
        items.Clear(); // Clear the list immediately

        // Then, spawn new ones
        for (int i = 0; i < 150; i++)
        {
            int r = UnityEngine.Random.Range(0, 100);
            GameObject newRils;

            if (r <= chanceForAdd) // Fixed: Now matches Awake() logic
            {
                newRils = Instantiate(reklama, contentRect);
                newRils.GetComponent<Fejk>().a.Resetplz();
            }
            else
            {
                newRils = Instantiate(rils, contentRect);

                // Assign random sprite
                int x = UnityEngine.Random.Range(1, 5); // Fixed: Now includes case 4
                Image img = newRils.GetComponent<Image>();

                switch (x)
                {
                    case 1: img.sprite = meme1; break;
                    case 2: img.sprite = meme2; break;
                    case 3: img.sprite = meme3; break;
                    case 4: img.sprite = meme4; break;
                    default: Debug.LogError("Invalid meme sprite!"); break;
                }
            }

            items.Add(newRils);
        }

        // Reset scroll position AFTER spawning new items
        //Refresh();
    }

    public void Refresh()
    {
        contentRect.anchoredPosition = startingPos; 
    }

    public void ValueChanged()
    {
        scrollTracker++;
    }

    public void scrollReached()
    {
        if (scrollTracker >= 10)
        {
            scrollClickClick.Play();
            scrollTracker = 0;
        }
    }
}