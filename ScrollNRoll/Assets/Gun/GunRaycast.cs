using UnityEngine;
using UnityEngine.UI;

public class GunRaycast : MonoBehaviour
{
    [Header("UI Elements")]
    public RectTransform cursorUI;      // Assign your crosshair UI element here
    public Transform crosshairPos;      // Optional: 3D crosshair representation

    [Header("Camera Settings")]
    public Camera fpsCam;               // Assign your FPS camera here

    [Header("Gun Audio")]
    public AudioSource audioSource;
    public AudioClip shootClip;
    public AudioClip dryShootClip;
    public AudioClip reloadClip;

    [Header("Raycast Settings")]
    public float range = 100f;
    public float rayDensity = 0.5f;

    [Header("Spawn Settings")]
    public GameObject testCube;
    public Vector3 spawnPosition = new Vector3(0.3f, 0.9f, -8.2f);
    public Quaternion spawnRotation = Quaternion.identity;
    

    void Start()
    {
        // Ensure the system cursor is visible
        Cursor.visible = true;
    }

    void Update()
    {
        // Update the position of the crosshair UI to match the mouse position
        if (cursorUI != null)
        {
            cursorUI.position = Input.mousePosition;
        }

        // Optional: Update the position of a 3D crosshair to match the UI crosshair
        // if (crosshairPos != null && cursorUI != null)
        // {
        //     crosshairPos.position = cursorUI.position;
            
        //     cursorUI.position = Input.mousePosition;
        // }

        // Fire raycast on left mouse button click
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        // Spawn test cube on F1 key press
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("Spawn enemy");
            SpawnCube();
        }
    }

    void Fire()
    {
        cursorUI.position = Input.mousePosition;
        // Cast a ray from the camera through the mouse position
        Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        audioSource.PlayOneShot(shootClip);

        if (Physics.SphereCast(ray, rayDensity, out hit, range))
        {
            Debug.Log("Hit " + hit.collider.name);

            // Optional: Apply damage if the object has a Health component
            Health target = hit.transform.GetComponent<Health>();
            if (target != null)
            {
                target.TakeDamage(50);
            }
        }
    }

    void SpawnCube()
    {
        Instantiate(testCube, spawnPosition, spawnRotation);
    }
}
