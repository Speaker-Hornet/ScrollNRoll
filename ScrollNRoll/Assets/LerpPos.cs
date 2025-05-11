using UnityEngine;

public class LerpPos : MonoBehaviour
{
    public float targetX = -3423.901f;         // Target X position
    public float duration = 8f;        // Time it takes to complete the lerp

    private float startX;
    private float elapsedTime;
    private bool isLerping = false;

    public void StartLerp()
    {
        startX = transform.position.x;
        elapsedTime = 0f;
        isLerping = true;
    }

    void Start()
    {
        StartLerp();   
    }

    void Update()
    {
        if (!isLerping) return;

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        float newX = Mathf.Lerp(startX, targetX, t);

        Vector3 position = transform.position;
        transform.position = new Vector3(newX, position.y, position.z);

        if (t >= 1f)
        {
            isLerping = false;
        }
        if (!isLerping){SceneManager.Instance.PlayGame();}
    }
}
