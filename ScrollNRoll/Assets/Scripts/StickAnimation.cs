using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickAnimation : MonoBehaviour
{
    public Image targetImage;

    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite idleSprite;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            targetImage.sprite = leftSprite;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetImage.sprite = rightSprite;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            targetImage.sprite = upSprite;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetImage.sprite = downSprite;
        }
        else
        {
            targetImage.sprite = idleSprite;
        }
    }
}
