using Unity.VisualScripting;
using UnityEngine;

public class Billboard : MonoBehaviour
{
   public Camera mainCamera;

    void Start()
    {
        mainCamera = ArcadeCarController.Instance.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (!mainCamera) mainCamera = ArcadeCarController.Instance.GetComponentInChildren<Camera>();
        if (mainCamera == null) return;
        mainCamera = Camera.main;
        // Make the sprite face the camera
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                        mainCamera.transform.rotation * Vector3.up);
    }
}