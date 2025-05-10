using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class FollowCursor : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The Canvas that contains this UI element")]
    public Canvas parentCanvas;
    [Tooltip("Offset from the cursor position")]
    public Vector2 offset = Vector2.zero;
    [Tooltip("Should the image be visible when the cursor is over UI elements?")]
    public bool showOverUI = true;

    private RectTransform rectTransform;
    private Image imageComponent;

    private void Awake()
    {
        Cursor.visible = false; // Hide system cursor
        rectTransform = GetComponent<RectTransform>();
        imageComponent = GetComponent<Image>();

        // If parent canvas isn't set, try to find it automatically
        if (parentCanvas == null)
        {
            parentCanvas = GetComponentInParent<Canvas>();
            if (parentCanvas == null)
            {
                Debug.LogError("Parent Canvas not assigned and couldn't be found automatically!");
            }
        }
    }

    private void Update()
    {
        if (parentCanvas == null) return;

        // Get cursor position in canvas space
        Vector2 cursorPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition,
            parentCanvas.worldCamera,
            out cursorPosition);

        // Apply offset and set position directly (no smoothing)
        rectTransform.anchoredPosition = cursorPosition + offset;

        // Handle visibility when over UI if needed
        if (!showOverUI)
        {
            bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            imageComponent.enabled = !isOverUI;
        }
    }
}