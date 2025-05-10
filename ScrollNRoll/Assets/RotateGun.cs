using UnityEngine;

public class RotateToGun : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    [SerializeField] Vector2 offset; // Optional offset from cursor

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Auto-find canvas if not set
        if (canvas == null)
        {
            canvas = GetComponentInParent<Canvas>();
            if (canvas == null)
            {
                Debug.LogError("Canvas not found! Please assign it manually.");
            }
        }
    }

    void Update()
    {
        if (canvas == null) return;

        // Get cursor position in canvas space
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out mousePos
        );

        // Move the image to cursor position (with optional offset)
        rectTransform.anchoredPosition = mousePos + offset;

        // Calculate rotation from pivot point to cursor
        Vector2 direction = mousePos - (Vector2)rectTransform.parent.InverseTransformPoint(rectTransform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}