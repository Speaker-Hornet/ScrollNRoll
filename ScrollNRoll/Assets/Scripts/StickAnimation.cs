using System.Collections.Generic;
using TMPro;
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

    bool a = true;
    bool w = true;
    bool s = true;
    bool d = true;
    bool idle = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            targetImage.sprite = leftSprite;
            if (a) SoundManager.Instance.PlaySwitchSound();
            a = false;
            d = true;
            w = true;
            s = true;
            idle = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetImage.sprite = rightSprite;
            if (d) SoundManager.Instance.PlaySwitchSound();
            a = true;
            d = false;
            w = true;
            s = true;
            idle = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            targetImage.sprite = upSprite;
            if (w) SoundManager.Instance.PlaySwitchSound();
            a = true;
            d = true;
            w = false;
            s = true;
            idle = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetImage.sprite = downSprite;
            if (s) SoundManager.Instance.PlaySwitchSound();
            a = true;
            d = true;
            w = true;
            s = false;
            idle = true;
        }
        else
        {
            targetImage.sprite = idleSprite;
            if (idle) SoundManager.Instance.PlaySwitchEndSound();
            a = true;
            d = true;
            w = true;
            s = true;
            idle = false;
        }
    }
}
