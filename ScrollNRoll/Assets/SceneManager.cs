using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

    [SerializeField] GameObject player;
    [SerializeField] GameObject intro;
    [SerializeField] GameObject ui;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        EnableIntro();
        DisablePlayer();
    }


    public void DisableIntro(){
        intro.SetActive(false);
    }
    public void EnableIntro(){
        intro.SetActive(true);
    }
    public void DisablePlayer(){
        player.SetActive(false);
    }
    public void EnablePlayer(){
        player.SetActive(true);
    }
    public void DisableUI(){
        ui.SetActive(false);
    }
    public void EnableUI(){
        ui.SetActive(true);
    }
}
