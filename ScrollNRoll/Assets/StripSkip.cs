using UnityEngine;

public class StripSkip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) SceneManager.Instance.SkipStrip();
    }
}
