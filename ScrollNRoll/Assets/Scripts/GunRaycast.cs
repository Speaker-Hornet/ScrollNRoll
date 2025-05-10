using UnityEngine;

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

    void Start()
    {
        // Start in center of screen
        cursorPos = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Cursor.visible = true; // Hide system cursor
    }

    void Update()
    {
        cursorUI.position = Input.mousePosition;

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("Spawn enemy");
            SpawnCube();
        }
    }

    void Fire()
    {
        Ray ray = fpsCam.ScreenPointToRay(cursorUI.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Hit " + hit.collider.name);

            // Optional: apply damage if the object has a Health component
            Health target = hit.transform.GetComponent<Health>();
            if (target != null)
            {
                target.TakeDamage(20);
            }
        } 
    }

    void SpawnCube()
    {
        Instantiate(testCube, spawnPosition, spawnRotation);
    }
}