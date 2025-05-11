using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera mainCamera;

    void Update()
    {
        if (mainCamera == null) return;
        mainCamera = Camera.main;
        // Make the sprite face the camera
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                        mainCamera.transform.rotation * Vector3.up);
    }
}