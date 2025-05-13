using System;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public int numberOfLaps;
    [NonSerialized]public int goalLaps;
    [NonSerialized]public bool startLinePassed;
    [NonSerialized]public bool midLinePassed;
    private bool ready;

    public event Action OnAddLaps;

    [NonSerialized]public float dopamineMax;
    public float dopamineCurrent;
    [NonSerialized] public float dopamineToDeplete;

    [NonSerialized] public int ammo;
    [NonSerialized] public int ammoToAdd;

    public GameObject rils;
    public GameObject guns;

    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI lapText;

    public GunRaycast shoot;

    //public event Action OnAddAmmo;


    public bool started;

    public GameObject win;

    [NonSerialized] public float timeToBeatRace;
    public TextMeshProUGUI timerText;
    public float elapsedTime;

    public GameObject lose;

    public ParticleSystem bigPow;

    public static GameManager Instance { get; private set; }

    public STATSOVI stats;


    private void Awake()
    {
        Instance = this;
        numberOfLaps = 0;
        dopamineMax = stats.DopamineMax;
        timeToBeatRace = stats.TimeToBeatRace;
        ammoToAdd = stats.AmmoAddedOnBuy;
        goalLaps = stats.NumberOfLaps;
        ammo = stats.AmmoOnStart;

    }
    
    public void AddAmmo()
    {
        bigPow.Play();
        //OnAddAmmo?.Invoke();
    }

    private void Start()
    {
        dopamineCurrent = dopamineMax;
    }

    private void Update()
    {
        if(dopamineCurrent > 100)
        {
            dopamineCurrent = 100;
        }

        if(started)
        {
            dopamineCurrent -= Time.deltaTime;

            if(dopamineCurrent <= 0)
            {
                Defeat();
            }

            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if(elapsedTime >= timeToBeatRace)
            {
                Defeat();
            }
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
                shoot.canShoot = true;
            }
            else
            {
                rils.SetActive(true);


                guns.SetActive(false);
                Cursor.visible = true;
                shoot.canShoot = false;
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
        win.SetActive(true);
        GameManager.Instance.GetComponent<AudioSource>().mute = true;
        Cursor.visible = true;
    }

    public void Defeat()
    {
        lose.SetActive(true);
        GameManager.Instance.GetComponent<AudioSource>().mute = true;
        Cursor.visible = true;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
