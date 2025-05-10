using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float damageAmount = 10f;
    public float healAmount = 10f;

    [Header("Needle Settings")]
    public float minNeedleAngle = 120f;
    public float maxNeedleAngle = -120f;

    [Header("UI Elements")]
    public Text healthLabel;
    public RectTransform needle;

    private void Update()
    {
        HandleInput();
        UpdateHealthDisplay();
    }

    private void HandleInput()
    {
        // Test case 1: Take damage with F3
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Debug.Log("dmg");
            currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        }

        // Test case 2: Heal with F4
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Debug.Log("heal");
            currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);
        }
    }

    private void UpdateHealthDisplay()
    {
        // Update health percentage and needle angle
        float healthPercentage = currentHealth / maxHealth;
        
        if (healthLabel != null)
        {
            healthLabel.text = $"{currentHealth:F0}/{maxHealth:F0}";
        }

        if (needle != null)
        {
            float targetAngle = Mathf.Lerp(minNeedleAngle, maxNeedleAngle, healthPercentage);
            needle.localEulerAngles = new Vector3(0, 0, targetAngle);
        }
    }
}