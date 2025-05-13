using UnityEngine;

public class EnemyFloat : MonoBehaviour
{
    [Header("Oscillation Settings")]
    [Tooltip("How far the object moves up and down")]
    [SerializeField] float amplitude = 0.5f;
    
    [Tooltip("How fast the object oscillates")]
    [SerializeField] float frequency = 1.0f;
    
    [Tooltip("Add a slight rotation while floating")]
    public bool addRotation = true;
    
    [Tooltip("Rotation speed")]
    public float rotationSpeed = 30.0f;
    
    // Store the starting position
    private Vector3 startPosition;
    
    void Start()
    {
        // Save the initial position
        startPosition = transform.position;
    }
    
    void Update()
    {
        // Calculate vertical position using a sine wave
        // Update the position
        float newY = startPosition.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
        
        // Add a slight rotation if enabled
        if (addRotation)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}