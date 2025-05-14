using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GunRaycast : MonoBehaviour
{
public GameObject newEnemyButton;
    
    [Header("Settings")]
    public Camera fpsCam;
    public RectTransform cursorUI;

    [Header("Raycast")]
    public float range = 100f;
    public float sensitivity  = 1.5f;
    public float maxRange     = 100f;

    [Header("Spawn Settings")]
    public GameObject testCube;
    public Vector3 spawnPosition = new Vector3(0.3f, 0.9f, -8.2f);
    public Quaternion spawnRotation = Quaternion.identity;

    private Vector2 cursorPos;

    public Image pucImage;

    public Sprite puc1;
    public Sprite puc2;
    public Sprite puc3;

    [SerializeField] ParticleSystem pow;

    public bool canShoot;

    void Start()
    {
        // Start in center of screen
        cursorPos = new Vector2(Screen.width / 2f, Screen.height / 2f);
        
    }

    void Update()
    {
        cursorUI.position = Input.mousePosition;

        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.Instance.ammo <= 0) {SoundManager.Instance.PlayNoAmmoSound(); return;}
            if (!canShoot) return;
            Fire();
            GameManager.Instance.ammo -= 1;
        }
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    Debug.Log("Spawn enemy");
        //    // SpawnCube();
        //}
    }

    void Fire()
    {
        pow.Play();
        int r = Random.Range(0, 3);
        switch(r)
        {
            case 0:
                {
                    pucImage.sprite = puc1;
                }break;
            case 1:
                {
                    pucImage.sprite = puc2;
                }
                break;
            case 2:
                {
                    pucImage.sprite = puc3;
                }
                break;
            }
        pucImage.gameObject.SetActive(true);
        SoundManager.Instance.PlayShootSound();
        Ray ray = fpsCam.ScreenPointToRay(cursorUI.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            // Optional: apply damage if the object has a Health component
            Health target = hit.transform.GetComponent<Health>();
            if (target != null)
            {
                target.TakeDamage(1);
            }
        }

        StartCoroutine(WaitThenDoSomething());
    }

    IEnumerator WaitThenDoSomething()
    {
        yield return new WaitForSeconds(0.1f);

        pucImage.gameObject.SetActive(false);

    }

    void SpawnCube()
    {
        Instantiate(testCube, spawnPosition, spawnRotation);
    }
}