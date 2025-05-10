using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArcadeCarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float acceleration = 1500f;
    public float maxSpeed = 50f;
    public float steering = 80f;
    public float driftFactor = 0.95f;
    public float grip = 2f;

    private Rigidbody rb;
    private float moveInput;
    private float steerInput;
    private Vector3 localVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.centerOfMass = new Vector3(0, -0.5f, 0); // improves stability
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        localVelocity = transform.InverseTransformDirection(rb.linearVelocity);

        // Limit max forward speed
        if (localVelocity.z < maxSpeed)
        {
            rb.AddForce(transform.forward * moveInput * acceleration * Time.fixedDeltaTime);
        }

        // Steering
        float steerAmount = steerInput * steering * Time.fixedDeltaTime * Mathf.Clamp01(localVelocity.z / 10f);
        Quaternion steerRotation = Quaternion.Euler(0, steerAmount, 0);
        rb.MoveRotation(rb.rotation * steerRotation);

        // Drift logic
        Vector3 driftForce = transform.right * Vector3.Dot(rb.linearVelocity, transform.right) * grip;
        rb.AddForce(-driftForce * driftFactor, ForceMode.Acceleration);
    }
}
