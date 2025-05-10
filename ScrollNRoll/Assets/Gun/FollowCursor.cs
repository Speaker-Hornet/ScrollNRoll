using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out mousePos
        );

       
        // Set the anchoredPosition of the RectTransform to follow the mouse
        rectTransform.anchoredPosition = mousePos;
    }

}
