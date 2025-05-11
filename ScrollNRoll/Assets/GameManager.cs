using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numberOfLaps;
    public int goalLaps;
    [NonSerialized]public bool startLinePassed;
    [NonSerialized]public bool midLinePassed;
    private bool ready;

    public event Action OnAddLaps;

    public float dopamineMax;
    public float dopamineCurrent;
    public float dopamineToDeplete;

    public int ammo;
    public int ammoToAdd;

    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        numberOfLaps = 0;
    }

    private void Start()
    {
        dopamineCurrent = dopamineMax;
    }

    private void Update()
    {
        if (startLinePassed && midLinePassed)
        {
            ready = true;
        }
    }

    public void CheckLine(string line)
    {
        Debug.Log("start" + "-" + startLinePassed);
        Debug.Log("mid" + "-" + midLinePassed);
        Debug.Log("ready" + "-" + ready);

        if(startLinePassed && midLinePassed && ready && line.Equals("Start"))
        {
            AddLaps();
            midLinePassed = false;
            startLinePassed = true;
        } 
    }

    public void AddLaps()
    {
        numberOfLaps++;

        Debug.Log(numberOfLaps + " !!!!!!!!!!!!!!!!!!!!!!");

        if(numberOfLaps == goalLaps)
        {
            Victory();
        }

        //UPDATE LAP UI COUNTER

        OnAddLaps?.Invoke();
    }

    public void Victory()
    {
        //logic
    }
}
