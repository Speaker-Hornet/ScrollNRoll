using System;
using UnityEngine;
using TMPro;

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

    public GameObject rils;
    public GameObject guns;

    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI lapText;



    public bool started;



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
        if(started)
        {
            dopamineCurrent -= Time.deltaTime;
        }

        if(dopamineCurrent <= 0)
        {
            Defeat();
        }

        if (startLinePassed && midLinePassed)
        {
            ready = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (rils.activeSelf == true)
            {
                rils.SetActive(false);


                guns.SetActive(true);
                Cursor.visible = false;
            }
            else
            {
                rils.SetActive(true);


                guns.SetActive(false);
                Cursor.visible = true;
            }
        }

        AmmoText.text = ammo.ToString();
        lapText.text = numberOfLaps.ToString() + "/2";
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

    public void Defeat()
    {

    }
}
