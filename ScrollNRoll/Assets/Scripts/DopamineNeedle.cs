using UnityEngine;
using UnityEngine.UI;

public class Dopamineometer : MonoBehaviour
{
    //public float maxHealth = 100.0f;
    public float minHealthArrowAngle = 90.0f;    // Angle when health is 0
    public float maxHealthArrowAngle = -90.0f;   // Angle when health is max
    public float healthChangeAmount = 10.0f;

    [Header("UI")]
    public RectTransform arrow;

    private float currentHealth;

    private void Start()
    {
        //currentHealth = maxHealth; // Initialize health
    }

    private void Update()
    {
        //HandleHealthInput();
        UpdateHealthMeter();
    }

    //private void HandleHealthInput()
    //{
    //    if (Input.GetKeyDown(KeyCode.F3))
    //    {
    //        // Take damage
    //        currentHealth = Mathf.Clamp(currentHealth - healthChangeAmount, 0, maxHealth);
    //    }
        
    //    if (Input.GetKeyDown(KeyCode.F4))
    //    {
    //        // Heal
    //        currentHealth = Mathf.Clamp(currentHealth + healthChangeAmount, 0, maxHealth);
    //    }
    //}

    private void UpdateHealthMeter()
    {
        if (arrow != null)
        {
            // Calculate health percentage and interpolate angle
            float healthPercentage = GameManager.Instance.dopamineCurrent / GameManager.Instance.dopamineMax;
            arrow.localEulerAngles = new Vector3(
                0, 
                0, 
                Mathf.Lerp(minHealthArrowAngle, maxHealthArrowAngle, healthPercentage)
            );
        }
    }
}