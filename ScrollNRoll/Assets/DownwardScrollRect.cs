using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[AddComponentMenu("UI/Downward Scroll Rect")]
public class DownwardScrollRect : ScrollRect
{
    private float lastValidPosition;
    private bool dragging;

    protected override void Start()
    {
        base.Start();
        lastValidPosition = verticalNormalizedPosition;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        // Only allow dragging if moving downward
        if (eventData.delta.y >= 0)
        {
            base.OnBeginDrag(eventData);
            dragging = true;
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (!dragging) return;

        // Continue only if moving downward
        if (eventData.delta.y >= 0)
        {
            base.OnDrag(eventData);
            lastValidPosition = verticalNormalizedPosition;
        }
        else
        {
            // Stop dragging if trying to scroll up
            dragging = false;
            StopMovement();
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (dragging)
        {
            base.OnEndDrag(eventData);
        }
        dragging = false;
    }

    public override void OnScroll(PointerEventData data)
    {
        // Only allow scrolling if moving downward
        if (data.scrollDelta.y >= 0)
        {
            base.OnScroll(data);
            lastValidPosition = verticalNormalizedPosition;
        }
    }

    private void Update()
    {
        // Constantly enforce the downward-only rule
        if (verticalNormalizedPosition < lastValidPosition)
        {
            verticalNormalizedPosition = lastValidPosition;
            velocity = Vector2.zero;
        }
        else
        {
            lastValidPosition = verticalNormalizedPosition;
        }
    }
}