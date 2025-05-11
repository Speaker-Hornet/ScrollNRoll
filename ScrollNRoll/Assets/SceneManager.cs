using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

    [SerializeField] GameObject player;
    [SerializeField] GameObject intro;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject shoot;
    [SerializeField] GameObject strip;
    [SerializeField] GameObject menu;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        EnableIntro();
        DisablePlayer();
    }

    public void EnableShoot(){
        shoot.SetActive(true);
    }
    public void DisableShoot(){
        shoot.SetActive(false);
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
    public void EnableStrip(){
        strip.SetActive(true);
    }
    public void DisableStrip(){
        strip.SetActive(false);
    }
    public void DisableMenu(){
        menu.SetActive(false);
    }

    public void PlayGame(){
        EnableUI();
        EnableShoot();
        EnablePlayer();

        DisableMenu();
        DisableIntro();
        DisableStrip();
    }
}
