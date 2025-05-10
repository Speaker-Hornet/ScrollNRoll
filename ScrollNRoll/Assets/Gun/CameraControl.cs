using UnityEngine;
using UnityEngine.UI;

public class CustomCursorController : MonoBehaviour
{
    public RectTransform cursorRectTransform;
    public float cursorSpeed = 1f;

    private Vector2 currentPos;

    void Start()
    {
        // Start in center of screen
        currentPos = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Cursor.visible = false; // Hide system cursor
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        currentPos += new Vector2(mouseX, mouseY) * cursorSpeed;

        // Clamp to screen bounds if you want
        currentPos.x = Mathf.Clamp(currentPos.x, 0, Screen.width);
        currentPos.y = Mathf.Clamp(currentPos.y, 0, Screen.height);

        cursorRectTransform.position = currentPos;
    }
}
