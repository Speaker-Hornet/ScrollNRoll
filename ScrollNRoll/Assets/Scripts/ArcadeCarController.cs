using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArcadeCarController : MonoBehaviour
{
    public static ArcadeCarController Instance;

    [Header("Car Settings")]
    [SerializeField] float acceleration = 1500f;
    [SerializeField] float deceleration = 800f;
    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float steering = 80f;
    [SerializeField] float driftFactor = 0.95f;
    [SerializeField] float grip = 2f;

    [NonSerialized]public Rigidbody rb;
    private float moveInput;
    private float steerInput;
    private Vector3 localVelocity;
    [SerializeField] float lowSpeedTurnRate;
    private float lowSpeedTurnRateConst;

    private float keepAcc;


    private void Awake()
    {
        Instance = this;
        keepAcc = acceleration;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.Instance.mobileMode();
    }

    void Update()
    {
        if (GameManager.Instance.isDead) return;
        if (GameManager.Instance.elapsedTime <= 3f)
        {
            acceleration = 0f;
        }
        else
        {
            acceleration = keepAcc;
        }

        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.isDead) return;
        localVelocity = transform.InverseTransformDirection(rb.linearVelocity);

        // Limit max forward speed
        if (localVelocity.z < maxSpeed && localVelocity.z > -maxSpeed)
        {
            if (localVelocity.z >= 0){
            rb.AddForce(transform.forward * moveInput * acceleration * Time.fixedDeltaTime);}
            if (localVelocity.z < 0){
            rb.AddForce(transform.forward * moveInput * deceleration * Time.fixedDeltaTime);}

        }

        // Steering
        HandleSteering();
        // Drift logic
        HandleDrift();
        
    }

    void HandleSteering(){
        if (localVelocity.z < 0.5){
            lowSpeedTurnRateConst = lowSpeedTurnRate;
        } 
        else {
            lowSpeedTurnRateConst = 0;
        }

        float steerAmount = steerInput * steering * Time.fixedDeltaTime * (Mathf.Clamp01(localVelocity.z / 10f) + lowSpeedTurnRateConst);
        Quaternion steerRotation = Quaternion.Euler(0, steerAmount, 0);
        rb.MoveRotation(rb.rotation * steerRotation);
    }
    void HandleDrift(){
        Vector3 driftForce = transform.right * Vector3.Dot(rb.linearVelocity, transform.right) * grip;
        rb.AddForce(-driftForce * driftFactor, ForceMode.Acceleration);
    }
}
