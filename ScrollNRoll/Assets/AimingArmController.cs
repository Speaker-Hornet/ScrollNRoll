using UnityEngine;
using UnityEngine.UI;

public class AimingArmController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform armTransform; // Reference to the arm's RectTransform
    [SerializeField] private Canvas parentCanvas; // Reference to the parent canvas

    [Header("Aiming Settings")]
    [SerializeField] private float maxOffsetDistance = 30f; // Maximum distance the arm can move from its anchor
    [SerializeField] private float followSpeed = 5f; // How quickly the arm follows the cursor
    [SerializeField] private float returnSpeed = 8f; // How quickly the arm returns to default position

    private Vector2 defaultAnchoredPosition;
    private Vector2 targetPosition;

    private void Awake()
    {
        // Store the default position (bottom right corner)
        defaultAnchoredPosition = armTransform.anchoredPosition;

        // If canvas isn't assigned, try to get it from the parent
        if (parentCanvas == null)
        {
            parentCanvas = GetComponentInParent<Canvas>();
        }
    }

    private void Update()
    {
        // Get cursor position in canvas space
        Vector2 cursorPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition,
            parentCanvas.worldCamera,
            out cursorPosition);

        // Calculate direction from default position to cursor
        Vector2 direction = (cursorPosition - defaultAnchoredPosition).normalized;

        // Calculate distance from default position to cursor (clamped to max offset)
        float distance = Mathf.Min(Vector2.Distance(defaultAnchoredPosition, cursorPosition), maxOffsetDistance);

        // Set target position (default position + direction * clamped distance)
        targetPosition = defaultAnchoredPosition + direction * distance;

        // Smoothly move towards target position
        if (Vector2.Distance(armTransform.anchoredPosition, targetPosition) > 0.1f)
        {
            // Use different speeds for following and returning
            float speed = (distance > Vector2.Distance(armTransform.anchoredPosition, defaultAnchoredPosition))
                ? followSpeed
                : returnSpeed;

            armTransform.anchoredPosition = Vector2.Lerp(
                armTransform.anchoredPosition,
                targetPosition,
                speed * Time.deltaTime);
        }
    }

    // Optional: Reset position when disabled
    private void OnDisable()
    {
        armTransform.anchoredPosition = defaultAnchoredPosition;
    }
}