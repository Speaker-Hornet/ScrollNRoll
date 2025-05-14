using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

    [SerializeField] GameObject player;
    [SerializeField] GameObject intro;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject shoot;
    [SerializeField] GameObject strip;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject countdown;
    [SerializeField] GameObject hurtUI;
    [SerializeField] Fader fader;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        EnableIntro();
        DisablePlayer();
    }
    
    IEnumerator WaitAndExecute(){
        yield return new WaitForSeconds(19f); // Wait for 20 seconds
        FadeToBlackAndBack(); // Call the function
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
        countdown.SetActive(true);
    }
    public void DisableUI(){
        ui.SetActive(false);
    }
    public void EnableUI(){
        ui.SetActive(true);
    }
    public void EnableStrip(){
        strip.SetActive(true);
        GameManager.Instance.loading = true;
        StartCoroutine(WaitAndExecute());
    }
    public void DisableStrip(){
        strip.SetActive(false);
    }
    public void DisableMenu(){
        menu.SetActive(false);
    }
    public void FadeToBlackAndBack(){
        //fader.FadeToBlackAndBack();
    }
    public void EnableHurtUI(){
        hurtUI.SetActive(true);
        StartCoroutine(DiableHurtUIOnTimer());
    }
    public void DisableHurtUI(){
        hurtUI.SetActive(false);
    }

    public void SkipStrip(){
        StopCoroutine(WaitAndExecute());
        StopAllCoroutines();
        PlayGame();
    }
    public void PlayGame(){
        EnableUI();
        EnableShoot();
        EnablePlayer();

        DisableMenu();
        DisableIntro();
        DisableStrip();
        GameManager.Instance.started = true;
        GameManager.Instance.loading=false;
    }

    public void Restart(){
        Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
    }

        IEnumerator DiableHurtUIOnTimer(){
            yield return new WaitForSeconds(0.5f);
            DisableHurtUI();

        }
}
