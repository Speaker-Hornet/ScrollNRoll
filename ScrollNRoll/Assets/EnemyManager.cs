using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] blockerSpawnPoints;
    public GameObject enemyBlockerPrefab;

    private List<int> spawnPointBlacklist;
    private List<GameObject> blockers;

    public GameObject enemyGroupiousPrefab;
    public float groupiousSpawnTime;
    private float currentTime;

    private void Start()
    {
        currentTime = 0f;
        blockers = new List<GameObject>();
        spawnPointBlacklist = new List<int>();

        for (int i = 0; i < 20; i++)
        {
            int r = Random.Range(0, 101);

            while (spawnPointBlacklist.Contains(r))
            {
                r = Random.Range(0, 101);
            }

            spawnPointBlacklist.Add(r);
            GameObject newBlocker = Instantiate(enemyBlockerPrefab, blockerSpawnPoints[r].transform.position, blockerSpawnPoints[r].transform.rotation);

            blockers.Add(newBlocker);
        }
        GameManager.Instance.OnAddLaps += SetupBlockers;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= groupiousSpawnTime)
        {
            Instantiate(enemyGroupiousPrefab);
            currentTime = 0f;
        }

    }

    public void SetupBlockers()
    {
        ResetBlockers();
        spawnPointBlacklist = new List<int>();

        for (int i = 0; i < 20; i++)
        {
            int r = Random.Range(0, 101);

            while (spawnPointBlacklist.Contains(r))
            {
                r = Random.Range(0, 101);
            }

            spawnPointBlacklist.Add(r);
            GameObject newBlocker = Instantiate(enemyBlockerPrefab, blockerSpawnPoints[r].transform.position, blockerSpawnPoints[r].transform.rotation);

            blockers.Add(newBlocker);
        }
    }

    public void ResetBlockers()
    {
        spawnPointBlacklist = null;

        foreach(GameObject blocker in blockers)
        {
            Destroy(blocker);
        }

        blockers.Clear();
    }
}
